﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HyperEnumGenerator
{
    [Generator]
    public class HyperEnumGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var enumItems = GetEnums(context).ToList();
            if (enumItems.Count <= 0) return;

            using var output = new StringWriter();
            using var writer = new IndentedTextWriter(output);
            writer.WriteLine("//<auto-generated/>");
            writer.WriteLine("using System;");
            writer.WriteLine("namespace HyperEnum");
            writer.WriteLine("{");
            writer.Indent++;
            writer.WriteLine("public static class HyperEnumExtensions");
            writer.WriteLine("{");
            writer.Indent++;

            foreach (var (name, members) in enumItems)
                WriteExtensionMethod(name, members, writer);

            writer.Indent--;
            writer.WriteLine("}");
            writer.Indent--;
            writer.WriteLine("}");
            context.AddSource("EnumExtensions.Generated", output.ToString());
        }

        private static void WriteExtensionMethod(string name, IEnumerable<string> members, IndentedTextWriter writer)
        {
            writer.WriteLine($"public static string GetName(this {name} member)");
            writer.WriteLine("{");
            writer.Indent++;
            writer.WriteLine("return member switch");
            writer.WriteLine("{");
            writer.Indent++;
            foreach (var member in members)
                writer.WriteLine($"{name}.{member} => \"{member}\",");

            writer.WriteLine("_ => throw new ArgumentOutOfRangeException(nameof(member), member, null)");
            writer.Indent--;
            writer.WriteLine("};");
            writer.Indent--;
            writer.WriteLine("}");
        }

        private static IEnumerable<(string Name, IEnumerable<string> Members)> GetEnums(
            GeneratorExecutionContext context)
        {
            return context.Compilation.SyntaxTrees
                .SelectMany(GetEnumItems)
                .Select(ParseEnum);
        }

        private static IEnumerable<EnumDeclarationSyntax> GetEnumItems(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot().DescendantNodes().OfType<EnumDeclarationSyntax>()
                .Where(x => x.AttributeLists.Any(q => Regex.IsMatch(q.ToString(), @"\[\s*?(?:HyperEnum|HyperEnumAttribute)\s*?\]")));
            
        }

        private static (string Name, IEnumerable<string> Members) ParseEnum(
            EnumDeclarationSyntax enumDeclarationSyntax)
        {
            return (GetEnumFullName(enumDeclarationSyntax),
                enumDeclarationSyntax.Members.Select(q => q.Identifier.Text));
        }

        private static string GetEnumFullName(BaseTypeDeclarationSyntax enumDeclarationSyntax)
        {
            return enumDeclarationSyntax.Parent switch
            {
                null => enumDeclarationSyntax.Identifier.Text,
                NamespaceDeclarationSyntax ns => string.Join(".", ns.Name.ToString(),
                    enumDeclarationSyntax.Identifier.Text),
                _ => string.Join(".", GetParentFullName(enumDeclarationSyntax.Parent),
                    enumDeclarationSyntax.Identifier.Text)
            };
        }
        private static string GetParentFullName(SyntaxNode syntaxNode)
        {
            return syntaxNode?.Kind() switch
            {
                null => string.Empty,
                SyntaxKind.ClassDeclaration => string.Join(".", GetParentFullName(syntaxNode.Parent),
                    ((ClassDeclarationSyntax)syntaxNode).Identifier.Text),
                SyntaxKind.StructDeclaration => string.Join(".", GetParentFullName(syntaxNode.Parent),
                    ((StructDeclarationSyntax)syntaxNode).Identifier.Text),
                SyntaxKind.RecordDeclaration => string.Join(".", GetParentFullName(syntaxNode.Parent),
                    ((RecordDeclarationSyntax)syntaxNode).Identifier.Text),
                SyntaxKind.NamespaceDeclaration => ((NamespaceDeclarationSyntax)syntaxNode).Name.ToString(),
                _ => throw new ArgumentOutOfRangeException(syntaxNode!.Kind().ToString())
            };
        }
    }
}