// //<auto-generated/>
// using System;
// using TestNamespace;
// namespace EnumTools
// {
//     public static class EnumExtensions
//     {
//         public static string Name(this HumanStates member)
//         {
//             return member switch
//             {
//                 HumanStates.Idle => "Idle",
//                 HumanStates.Working => "Working",
//                 HumanStates.Sleeping => "Sleeping",
//                 HumanStates.Eating => "Eating",
//                 HumanStates.Dead => "Dead",
//                 _ => throw new ArgumentOutOfRangeException(nameof(member), member, null)
//             };
//         }
//         public static string Name(this Test3 member)
//         {
//             return member switch
//             {
//                 Test3.Item1 => "Item1",
//                 Test3.Item2 => "Item2",
//                 _ => throw new ArgumentOutOfRangeException(nameof(member), member, null)
//             };
//         }
//     }
// }