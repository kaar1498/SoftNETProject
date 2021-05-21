using System;
using System.Linq;
using Bogus;

namespace SoftNETProject.Data
{
    public class DbInitialize
    {
        internal static void Initialize(SoftNETProjectContext context)
        {
            if (context.Product.Any())
            {
                return;
            }

            Randomizer.Seed = new Random(1234);

            var productNames = new[] { "appelsin", "brød", "havegryn", "oksekød", "pepsi", "tabasco", "tun", "tyggegumi", "æble" };
            var productDescriptions = new[] { "so yummmy!", "lavet på dansk måde", "nu med 100% mere frugt", "garanteret glæde", "advarsel: meget lækkert", "mere en to er fint" };

            var categories = new Faker<Category>()
                .RuleFor(o => o.Name, c => c.Lorem.Word())
                .RuleFor(o => o.Description, c => c.Lorem.Paragraph());

            var suppliers = new Faker<Supplier>()
                .RuleFor(o => o.Name, s => s.Lorem.Word())
                .RuleFor(o => o.Address, s => s.Address.FullAddress())
                .RuleFor(o => o.Postcode, s => s.Address.ZipCode())
                .RuleFor(o => o.ContactPerson, s => s.Person.FullName)
                .RuleFor(o => o.Email, s => s.Person.Email)
                .RuleFor(o => o.Phone, s => s.Person.Phone);

            var products = new Faker<Product>()
                .RuleFor(o => o.Name, p => p.PickRandom(productNames))
                .RuleFor(o => o.Description, p => p.PickRandom(productDescriptions))
                .RuleFor(o => o.Unit, p => p.Lorem.Word())
                .RuleFor(o => o.Amount, p => p.Random.Int(1, 20))
                .RuleFor(o => o.Price, p => p.Random.Double(4.5, 199.99))
                .RuleFor(o => o.Category, p => categories.Generate(1).First())
                .RuleFor(o => o.Supplier, p => suppliers.Generate(1).First());

            var productGen = products.Generate(5);

            context.AddRange(categories.Generate(5));
            context.AddRange(suppliers.Generate(1));
            context.AddRange(productGen);

            context.SaveChanges();
        }
    }
}
