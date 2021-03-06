using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveStore.Models
{
    public class SeedData
    {
        public static void AutomotiveDataFilling(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange
                    (

                    new Product
                    {
                        Name = "Motul 10w30 5l",
                        Description = "Olej do samochodu.",
                        Category = "Oleje silnikowe",
                        Price = 129.99m
                    },

                    new Product
                    {
                        Name = "Pokrowiec na samochód",
                        Description = "Pokrowiec chroniący pojazd stojący na zewnątrz przed złymi warunkami pogodowymi.",
                        Category = "ochrona pojazdu",
                        Price = 99
                    },

                    new Product
                    {
                        Name = "Żarówka Bosch H4",
                        Description = "żarówka halogenowa do świateł drogowych. ",
                        Category = "Oświetlenie",
                        Price = 49.89m
                    },

                    new Product
                    {
                        Name = "Aktywna piana do mycia auta o zapachu cytrusów",
                        Description = "Bezpieczny piana do mycia samochodów o neutralnym ph nie niszcząca lakieru auta.",
                        Category = "Kosmetyki samochodowe",
                        Price = 25
                    },

                    new Product
                    {
                        Name = "Zestaw naprawczy do kół",
                        Description = "Zestaw do naprawy przebitych kół wystarczający na naprawe 4 opon.",
                        Category = "Naprawy i awarie",
                        Price = 87.99m
                    },

                    new Product
                    {
                        Name = "filtr kabinowy Marki filtron",
                        Description = "filtr kabinowy pasujący do samochodów marki Toyota z lat 2000-2009.",
                        Category = "Filtry",
                        Price = 40
                    },

                    new Product
                    {
                        Name = "Trójkąt ostrzegawczy",
                        Description = "Składany trójkąt ostrzegawczy, obowiazkowy element każdego samochodu.",
                        Category = "Akcesoria",
                        Price = 14.99m
                    },
                     new Product
                     {
                         Name = "Sprzęgło",
                         Description = "do samochodów marki:audi, mercedes, fiat, opel, toyota",
                         Category = "Części samochodowe",
                         Price = 399
                     },
                      new Product
                      {
                          Name = "filtr kabinowy Marki filtron",
                          Description = "filtr kabinowy pasujący do samochodów marki audi.",
                          Category = "Filtry",
                          Price = 45
                      },
                       new Product
                       {
                           Name = "filtr powietrza",
                           Description = "filtr uniwersalny",
                           Category = "Filtry",
                           Price = 25
                       },
                        new Product
                        {
                            Name = "zestaw kluczy warsztatowych",
                            Description = "Zestaw najważniejszych narzędzi potrzebnych w domowym warsztacie. ",
                            Category = "Akcesoria",
                            Price = 578
                        },
                         new Product
                         {
                             Name = "Klocki hamulcowe",
                             Description = "Zestaw klocków hamulcowych do samochodów marki  ford.",
                             Category = "Części Samochodowe",
                             Price = 220
                         },
                          new Product
                          {
                              Name = "Sportowe zaciski hamulcowe brembo",
                              Description = "zestaw hamulców renomowanej marki Brembo do samochodów sportowych.",
                              Category = "Części Samochodowe",
                              Price = 774
                          },
                           new Product
                           {
                               Name = "Płyn do mycia felg aluminiowych",
                               Description = "bezpieczny płyn czyszczenia felg.",
                               Category = "Kosmetyki samochodowe",
                               Price = 774
                           }


                    );
                context.SaveChanges();
            }
        }
    }
}
