// See https://aka.ms/new-console-template for more information


using HashtableAssignment.Library;
Console.Clear();

TableBuilder table = new TableBuilder("Handy Hardware - Product Inventory");

table.AddProduct("Duct Tape", 23);
table.AddProduct("Measuring Tape", 5);

table.BuildHeader();
table.DisplayAllProducts();


