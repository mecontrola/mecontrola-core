﻿using System;

namespace MeControla.Core.Tests.Mocks
{
    public class DataMock
    {
        public static string TEXT_SPACES { get; } = "    Simply      String    Test    Encode  ";
        public static string TEXT_DECODE { get; } = "Simply String Test Encode";
        public static string TEXT_ENCODE { get; } = "U2ltcGx5IFN0cmluZyBUZXN0IEVuY29kZQ==";
        public static string TEXT_ENCODE_MD5 { get; } = "e26c3a1b5f4f4b2a9096548e77ea89e7";
        public static string VALUE_DEFAULT_TEXT { get; } = "Simply String Test";
        public static string VALUE_DEFAULT_TEXT2 { get; } = "Simply String Test Anything";
        public static string JSON_CLASS_TEST { get; } = @"{""field_in_class1"":5,""field_in_class2"":9}";
        public static string TEXT_DATETIME { get; } = "2000-05-05";
        public static string TEXT_DECIMAL { get; } = "100.0";
        public static string TEXT_URL { get; } = "http://myhost.com";

        public static int VALUE_DEFAULT_5 { get; } = 5;
        public static int VALUE_DEFAULT_9 { get; } = 9;
        public static int WEEK_YEAR { get; } = 18;

        public static DateTime DATETIME_QUARTER_2_2000 { get; } = new(2000, 5, 5);

        public static decimal DECIMAL_DEFAULT { get; } = 100;

        public static string CONFIG_VALUE_1 { get; } = "value1";
        public static string CONFIG_VALUE_2 { get; } = "value2";

        public static long INT_ID_1 { get; } = 1;
        public static long INT_ID_2 { get; } = 2;
        public static long INT_ID_3 { get; } = 3;
        public static long INT_ID_4 { get; } = 4;

        public static Guid UUID_USER_1 { get; } = Guid.Parse("d90034e8-f46f-481f-b7e7-2b6bb86b2b45");
        public static Guid UUID_USER_2 { get; } = Guid.Parse("cc496a87-9a98-4a78-afab-cf53c04d0b65");
        public static Guid UUID_USER_3 { get; } = Guid.Parse("50a5f162-5209-4bc8-bc40-07ae51454483");
        public static Guid UUID_USER_4 { get; } = Guid.Parse("7d95d4c6-c43c-43ac-9ddc-d0b43718bc32");
        public static Guid UUID_PERMISSION_1 { get; } = Guid.Parse("f4735182-2e2c-4036-a816-3d8d65ff2dfc");
        public static Guid UUID_PERMISSION_2 { get; } = Guid.Parse("eca93db5-0a30-46f0-8599-06d55f70e1d4");

        public static string TEXT_USER_NAME_1 { get; } = "Diogo Henrique Teixeira";
        public static string TEXT_USER_NAME_2 { get; } = "Lucas Vicente Isaac Peixoto";
        public static string TEXT_USER_NAME_3 { get; } = "Agatha Andrea Sebastiana Lima";
        public static string TEXT_USER_NAME_4 { get; } = "Bryan Nicolas Marcos Vinicius Pires";
        public static string TEXT_PERMISSION_NAME_1 { get; } = "Administrator";
        public static string TEXT_PERMISSION_NAME_2 { get; } = "User";
    }
}