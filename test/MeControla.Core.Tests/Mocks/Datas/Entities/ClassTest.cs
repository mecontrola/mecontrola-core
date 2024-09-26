using System;
using System.ComponentModel;

namespace MeControla.Core.Tests.Mocks.Datas.Entities;

public class ClassTest
{
    [Description("TestValue")]
    public int FieldInClass1 { get; set; }
    public int FieldInClass2 { get; set; }
    public DateTime FieldDateTime { get; set; }
}