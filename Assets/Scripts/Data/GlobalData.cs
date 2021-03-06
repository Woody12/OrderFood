using System;

static class GlobalData
{
	public static string restaurantData = @"[{
		""id"": 0,
		""category"": 0,
		""name"": ""Jack's Burger"",
		""address"": ""100 Main Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 1,
		""category"": 1,
		""name"": ""Panda Express"",
		""address"": ""110 Jack Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 2,
		""category"": 1,
		""name"": ""Asian Pearl"",
		""address"": ""240 Temple Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 3,
		""category"": 2,
		""name"": ""Gyro Bay"",
		""address"": ""250 Smith Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
""id"": 4,
		""category"": 2,
		""name"": ""Awesome Gyro"",
		""address"": ""3560 Big Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 5,
		""category"": 3,
		""name"": ""Mexico Lindo"",
		""address"": ""270 St John Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 6,
		""category"": 3,
		""name"": ""Green Burrito"",
		""address"": ""350 Bay Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	}
]";

	public static string menuData = @"[{
		""id"": 0,
		""category"": 0,
		""menuDetails"": [{
			""name"": ""Cheeseburger"",
			""description"": ""Classic burger with American cheese"",
			""imageName"": ""Hamburger"",
			""price"": ""5.99""
		},
		{
			""name"": ""Hamburger"",
			""description"": ""Flame boiled burger"",
			""imageName"": ""Hamburger"",
			""price"": ""4.99""
		}]
	},
	{
		""id"": 1,
		""category"": 1,
		""menuDetails"": [{
			""name"": ""Noodle Dish"",
			""description"": ""Yummy special noodle dish"",
			""imageName"": ""Chinese"",
			""price"": ""8.99""
		},
		{
			""name"": ""Sweet Sour Pork"",
			""description"": ""Sweet delight"",
			""imageName"": ""Chinese"",
			""price"": ""10.99""
		},
		{
			""name"": ""Kung Pao Chicken"",
			""description"": ""Love the Spicyness"",
			""imageName"": ""Chinese"",
			""price"": ""9.99""
		}]
	},
	{
		""id"": 2,
		""category"": 2,
		""menuDetails"": [{
			""name"": ""Sweet Gyro"",
			""description"": ""Our signature dish"",
			""imageName"": ""Gyro"",
			""price"": ""10.99""
		}]
	},
	{
		""id"": 3,
		""category"": 3,
		""menuDetails"": [{
			""name"": ""Burrito"",
			""description"": ""To die for"",
			""imageName"": ""Mex"",
			""price"": ""9.99""
		},
		{
			""name"": ""Taco"",
			""description"": ""Crispy and Yummy"",
			""imageName"": ""Mex"",
			""price"": ""7.99""
		},
		{
			""name"": ""Tamales"",
			""description"": ""Tender... ooh.."",
			""imageName"": ""Mex"",
			""price"": ""8.99""
		},
		{
			""name"": ""Chips & Salsa"",
			""description"": ""Don't forget the dips"",
			""imageName"": ""Mex"",
			""price"": ""4.99""
		}]
	}
]";
}