﻿using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Helpers
{
    public class PetooDbInitializer : DropCreateDatabaseAlways<AccountContext> //TODO create if not exists
    {
        protected override void Seed(AccountContext context)
        {
            var male = new Gender { Id = 1, Name = "Male" };
            var female = new Gender { Id = 2, Name = "Female" };
            context.Genders.AddRange(new List<Gender> { male, female });

            var admin = new Role { Id = 1, Name = "Admin" };
            var user = new Role { Id = 2, Name = "User" };
            var breeder = new Role { Id = 3, Name = "Breeder" };
            context.Roles.AddRange(new List<Role> { admin, user, breeder });

            var regLogin = new Login { Password = "regular", UserLogin = "regular" };
            var reg2Login = new Login { Password = "regular2", UserLogin = "regular2" };
            var breedLogin = new Login { Password = "breeder", UserLogin = "breeder" };
            var admLogin = new Login { Password = "admin", UserLogin = "admin" };
            context.Logins.AddRange(new List<Login> { regLogin, admLogin, reg2Login, breedLogin });

            var regularUser = new User() { Id = 1, FirstName = "Reqular", LastName = "User", Login = regLogin, Role = user, Email = "reg@reg.com" };
            var regular2 = new User() { Id = 2, FirstName = "Reqular2", LastName = "User2", Login = reg2Login, Role = user, Email = "reg2@reg.com" };
            var adminUser = new User() { Id = 3, FirstName = "Admin", LastName = "Administrator", Login = admLogin, Role = admin };
            context.Users.AddRange(new List<User> { regularUser, adminUser, regular2 });

            context.Breeders.Add(new Breeder { Id = 1, FirstName = "Breeder", LastName = "Breeder", Email = "breed@gmail.com", Login = breedLogin, Role = breeder, WebSite = "http://designbyis.com/" });

            context.Shows.AddRange(ShowsList());

            context.Breeds.AddRange(FullBreedsList());

            context.Pets.AddRange(LotOfPetsList());

            var lst = new List<Ancestry>();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedDocs", "ancestry.pdf");
            lst.Add(new Ancestry { Id = 1, FatherId = 5, MotherId = 17, DocumentPath = filePath });
            lst.Add(new Ancestry { Id = 2, FatherId = 7, MotherId = 18, DocumentPath = filePath });
            lst.Add(new Ancestry { Id = 3, FatherId = 10, MotherId = 20, DocumentPath = filePath });
            lst.Add(new Ancestry { Id = 4, FatherId = 12, MotherId = 22, DocumentPath = filePath });
            context.Ancestries.AddRange(lst);


            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "1.jpg");
            //var pet = new Pet { BreedId = 223, Name = "Archie", User = regularUser, Age = 3, Gender = male, ImagePath = filePath };

            //filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "2.jpg");
            //var pet1 = new Pet { BreedId = 454, Name = "Kora", User = regularUser, Age = 5, Gender = female, ImagePath = filePath };

            //filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "4.jpg");
            //var pet2 = new Pet { BreedId = 21, Name = "Bonya", User = regularUser, Age = 11, Gender = male, ImagePath = filePath };

            //filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "3.jpg");
            //var pet3 = new Pet { BreedId = 56, Name = "Sherlock", User = regularUser, Age = 6, Gender = male, ImagePath = filePath };
            //context.Pets.AddRange(new List<Pet>() { pet, pet1, pet2, pet3 });

            base.Seed(context);
        }

        private List<Breed> FullBreedsList()
        {
            var lst = new List<Breed>();
            lst.Add(new Breed { Name = "No breed                              " });
            lst.Add(new Breed { Name = "Affenpinscher                         " });
            lst.Add(new Breed { Name = "Afghan Hound                          " });
            lst.Add(new Breed { Name = "Afghan Shepherd                       " });
            lst.Add(new Breed { Name = "Aidi                                  " });
            lst.Add(new Breed { Name = "Airedale Terrier                      " });
            lst.Add(new Breed { Name = "Akbash                                " });
            lst.Add(new Breed { Name = "Akita                                 " });
            lst.Add(new Breed { Name = "Alano Español                         " });
            lst.Add(new Breed { Name = "Alaskan husky                         " });
            lst.Add(new Breed { Name = "Alaskan Klee Kai                      " });
            lst.Add(new Breed { Name = "Alaskan Malamute                      " });
            lst.Add(new Breed { Name = "Alaunt                                " });
            lst.Add(new Breed { Name = "Alopekis                              " });
            lst.Add(new Breed { Name = "Alpine Dachsbracke                    " });
            lst.Add(new Breed { Name = "Alpine Mastiff                        " });
            lst.Add(new Breed { Name = "Alpine Spaniel                        " });
            lst.Add(new Breed { Name = "American Akita                        " });
            lst.Add(new Breed { Name = "American Bully                        " });
            lst.Add(new Breed { Name = "American Bulldog                      " });
            lst.Add(new Breed { Name = "American Cocker Spaniel               " });
            lst.Add(new Breed { Name = "American English Coonhound            " });
            lst.Add(new Breed { Name = "American Eskimo Dog                   " });
            lst.Add(new Breed { Name = "American Foxhound                     " });
            lst.Add(new Breed { Name = "American Hairless Terrier             " });
            lst.Add(new Breed { Name = "American Pit Bull Terrier             " });
            lst.Add(new Breed { Name = "American Staffordshire Terrier        " });
            lst.Add(new Breed { Name = "American Water Spaniel                " });
            lst.Add(new Breed { Name = "Anatolian Shepherd Dog                " });
            lst.Add(new Breed { Name = "Andalusian Hound                      " });
            lst.Add(new Breed { Name = "Anglo - Français de Petite Vénerie    " });
            lst.Add(new Breed { Name = "Appenzeller Sennenhund                " });
            lst.Add(new Breed { Name = "Argentine Polar Dog                   " });
            lst.Add(new Breed { Name = "Ariegeois                             " });
            lst.Add(new Breed { Name = "Armant                                " });
            lst.Add(new Breed { Name = "Armenian Gampr dog                    " });
            lst.Add(new Breed { Name = "Artois Hound                          " });
            lst.Add(new Breed { Name = "Australian Cattle Dog                 " });
            lst.Add(new Breed { Name = "Australian Kelpie                     " });
            lst.Add(new Breed { Name = "Australian Shepherd                   " });
            lst.Add(new Breed { Name = "Australian Stumpy Tail Cattle Dog     " });
            lst.Add(new Breed { Name = "Australian Terrier                    " });
            lst.Add(new Breed { Name = "Austrian Black and Tan Hound          " });
            lst.Add(new Breed { Name = "Austrian Pinscher                     " });
            lst.Add(new Breed { Name = "Azawakh                               " });
            lst.Add(new Breed { Name = "Bakharwal dog                         " });
            lst.Add(new Breed { Name = "Barbado da Terceira                   " });
            lst.Add(new Breed { Name = "Barbet                                " });
            lst.Add(new Breed { Name = "Basenji                               " });
            lst.Add(new Breed { Name = "Basque Shepherd Dog                   " });
            lst.Add(new Breed { Name = "Basset Artésien Normand               " });
            lst.Add(new Breed { Name = "Basset Bleu de Gascogne               " });
            lst.Add(new Breed { Name = "Basset Fauve de Bretagne              " });
            lst.Add(new Breed { Name = "Basset Hound                          " });
            lst.Add(new Breed { Name = "Bavarian Mountain Hound               " });
            lst.Add(new Breed { Name = "Beagle                                " });
            lst.Add(new Breed { Name = "Beagle - Harrier                      " });
            lst.Add(new Breed { Name = "Bearded Collie                        " });
            lst.Add(new Breed { Name = "Beauceron                             " });
            lst.Add(new Breed { Name = "Bedlington Terrier                    " });
            lst.Add(new Breed { Name = "Belgian Shepherd Dog(Groenendael)     " });
            lst.Add(new Breed { Name = "Belgian Shepherd Dog(Laekenois)       " });
            lst.Add(new Breed { Name = "Belgian Shepherd Dog(Malinois)        " });
            lst.Add(new Breed { Name = "Belgian Shepherd Dog(Tervuren)        " });
            lst.Add(new Breed { Name = "Bergamasco Shepherd                   " });
            lst.Add(new Breed { Name = "Berger Blanc Suisse                   " });
            lst.Add(new Breed { Name = "Berger Picard                         " });
            lst.Add(new Breed { Name = "Bernese Mountain Dog                  " });
            lst.Add(new Breed { Name = "Bichon Frisé                          " });
            lst.Add(new Breed { Name = "Billy                                 " });
            lst.Add(new Breed { Name = "Black and Tan Coonhound               " });
            lst.Add(new Breed { Name = "Black and Tan Virginia Foxhound       " });
            lst.Add(new Breed { Name = "Black Norwegian Elkhound              " });
            lst.Add(new Breed { Name = "Black Russian Terrier                 " });
            lst.Add(new Breed { Name = "Black Mouth Cur                       " });
            lst.Add(new Breed { Name = "Bloodhound                            " });
            lst.Add(new Breed { Name = "Blue Heeler                           " });
            lst.Add(new Breed { Name = "Blue Lacy                             " });
            lst.Add(new Breed { Name = "Blue Paul Terrier                     " });
            lst.Add(new Breed { Name = "Blue Picardy Spaniel                  " });
            lst.Add(new Breed { Name = "Bluetick Coonhound                    " });
            lst.Add(new Breed { Name = "Boerboel                              " });
            lst.Add(new Breed { Name = "Bohemian Shepherd                     " });
            lst.Add(new Breed { Name = "Bolognese                             " });
            lst.Add(new Breed { Name = "Border Collie                         " });
            lst.Add(new Breed { Name = "Border Terrier                        " });
            lst.Add(new Breed { Name = "Borzoi                                " });
            lst.Add(new Breed { Name = "Bosnian Coarse - haired Hound         " });
            lst.Add(new Breed { Name = "Boston Terrier                        " });
            lst.Add(new Breed { Name = "Bouvier des Ardennes                  " });
            lst.Add(new Breed { Name = "Bouvier des Flandres                  " });
            lst.Add(new Breed { Name = "Boxer                                 " });
            lst.Add(new Breed { Name = "Boykin Spaniel                        " });
            lst.Add(new Breed { Name = "Bracco Italiano                       " });
            lst.Add(new Breed { Name = "Braque d'Auvergne                     " });
            lst.Add(new Breed { Name = "Braque de l'Ariege                    " });
            lst.Add(new Breed { Name = "Braque du Bourbonnais                 " });
            lst.Add(new Breed { Name = "Braque du Puy                         " });
            lst.Add(new Breed { Name = "Braque Francais                       " });
            lst.Add(new Breed { Name = "Braque Saint-Germain                  " });
            lst.Add(new Breed { Name = "Brazilian Dogo                        " });
            lst.Add(new Breed { Name = "Brazilian Terrier                     " });
            lst.Add(new Breed { Name = "Briard                                " });
            lst.Add(new Breed { Name = "Briquet Griffon Vendéen               " });
            lst.Add(new Breed { Name = "Brittany                              " });
            lst.Add(new Breed { Name = "Broholmer                             " });
            lst.Add(new Breed { Name = "Bruno Jura Hound                      " });
            lst.Add(new Breed { Name = "Brussels Griffon                      " });
            lst.Add(new Breed { Name = "Bucovina Shepherd Dog                 " });
            lst.Add(new Breed { Name = "Bull and Terrier                      " });
            lst.Add(new Breed { Name = "Bull Terrier                          " });
            lst.Add(new Breed { Name = "Bulldog                               " });
            lst.Add(new Breed { Name = "Bullenbeisser                         " });
            lst.Add(new Breed { Name = "Bullmastiff                           " });
            lst.Add(new Breed { Name = "Bully Kutta                           " });
            lst.Add(new Breed { Name = "Burgos Pointer                        " });
            lst.Add(new Breed { Name = "Cairn Terrier                         " });
            lst.Add(new Breed { Name = "Canaan Dog                            " });
            lst.Add(new Breed { Name = "Canadian Eskimo Dog                   " });
            lst.Add(new Breed { Name = "Cane Corso                            " });
            lst.Add(new Breed { Name = "Cane Pecoraio Varbutu                 " });
            lst.Add(new Breed { Name = "Cantabrian Water Dog                  " });
            lst.Add(new Breed { Name = "Cão da Serra de Aires                 " });
            lst.Add(new Breed { Name = "Cão de Castro Laboreiro               " });
            lst.Add(new Breed { Name = "Cão de Gado Transmontano              " });
            lst.Add(new Breed { Name = "Cão Fila de São Miguel                " });
            lst.Add(new Breed { Name = "Carolina Dog                          " });
            lst.Add(new Breed { Name = "Carpathian Shepherd Dog               " });
            lst.Add(new Breed { Name = "Catalan Sheepdog                      " });
            lst.Add(new Breed { Name = "Caucasian Shepherd Dog                " });
            lst.Add(new Breed { Name = "Cavalier King Charles Spaniel         " });
            lst.Add(new Breed { Name = "Central Asian Shepherd Dog            " });
            lst.Add(new Breed { Name = "Cesky Fousek                          " });
            lst.Add(new Breed { Name = "Cesky Terrier                         " });
            lst.Add(new Breed { Name = "Chesapeake Bay Retriever              " });
            lst.Add(new Breed { Name = "Chien Français Blanc et Noir          " });
            lst.Add(new Breed { Name = "Chien Français Blanc et Orange        " });
            lst.Add(new Breed { Name = "Chien Français Tricolore              " });
            lst.Add(new Breed { Name = "Chien - gris                          " });
            lst.Add(new Breed { Name = "Chihuahua                             " });
            lst.Add(new Breed { Name = "Chilean Terrier                       " });
            lst.Add(new Breed { Name = "Chinese Chongqing Dog                 " });
            lst.Add(new Breed { Name = "Chinese Crested Dog                   " });
            lst.Add(new Breed { Name = "Chinese Imperial Dog                  " });
            lst.Add(new Breed { Name = "Chinook                               " });
            lst.Add(new Breed { Name = "Chippiparai                           " });
            lst.Add(new Breed { Name = "Chiribaya Dog                         " });
            lst.Add(new Breed { Name = "Chow Chow                             " });
            lst.Add(new Breed { Name = "Cierny Sery                           " });
            lst.Add(new Breed { Name = "Cirneco dell'Etna                     " });
            lst.Add(new Breed { Name = "Clumber Spaniel                       " });
            lst.Add(new Breed { Name = "Collie, Rough                         " });
            lst.Add(new Breed { Name = "Collie, Smooth                        " });
            lst.Add(new Breed { Name = "Combai                                " });
            lst.Add(new Breed { Name = "Cordoba Fighting Dog                  " });
            lst.Add(new Breed { Name = "Coton de Tulear                       " });
            lst.Add(new Breed { Name = "Cretan Hound                          " });
            lst.Add(new Breed { Name = "Croatian Sheepdog                     " });
            lst.Add(new Breed { Name = "Cumberland Sheepdog                   " });
            lst.Add(new Breed { Name = "Curly - Coated Retriever              " });
            lst.Add(new Breed { Name = "Cursinu                               " });
            lst.Add(new Breed { Name = "Czechoslovakian Wolfdog               " });
            lst.Add(new Breed { Name = "Dachshund                             " });
            lst.Add(new Breed { Name = "Dalbo dog                             " });
            lst.Add(new Breed { Name = "Dalmatian                             " });
            lst.Add(new Breed { Name = "Dandie Dinmont Terrier                " });
            lst.Add(new Breed { Name = "Danish - Swedish Farmdog              " });
            lst.Add(new Breed { Name = "Deutsche Bracke                       " });
            lst.Add(new Breed { Name = "Doberman Pinscher                     " });
            lst.Add(new Breed { Name = "Dogo Argentino                        " });
            lst.Add(new Breed { Name = "Dogo Cubano                           " });
            lst.Add(new Breed { Name = "Dogue de Bordeaux                     " });
            lst.Add(new Breed { Name = "Drentse Patrijshond                   " });
            lst.Add(new Breed { Name = "Drever                                " });
            lst.Add(new Breed { Name = "Dunker                                " });
            lst.Add(new Breed { Name = "Dutch Shepherd                        " });
            lst.Add(new Breed { Name = "Dutch Smoushond                       " });
            lst.Add(new Breed { Name = "East Siberian Laika                   " });
            lst.Add(new Breed { Name = "East European Shepherd                " });
            lst.Add(new Breed { Name = "Elo                                   " });
            lst.Add(new Breed { Name = "English Cocker Spaniel                " });
            lst.Add(new Breed { Name = "English Foxhound                      " });
            lst.Add(new Breed { Name = "English Mastiff                       " });
            lst.Add(new Breed { Name = "English Pointer                       " });
            lst.Add(new Breed { Name = "English Setter                        " });
            lst.Add(new Breed { Name = "English Shepherd                      " });
            lst.Add(new Breed { Name = "English Springer Spaniel              " });
            lst.Add(new Breed { Name = "English Toy Terrier(Black &Tan)       " });
            lst.Add(new Breed { Name = "English Water Spaniel                 " });
            lst.Add(new Breed { Name = "English White Terrier                 " });
            lst.Add(new Breed { Name = "Entlebucher Mountain Dog              " });
            lst.Add(new Breed { Name = "Estonian Hound                        " });
            lst.Add(new Breed { Name = "Estrela Mountain Dog                  " });
            lst.Add(new Breed { Name = "Eurasier                              " });
            lst.Add(new Breed { Name = "Eurohound                             " });
            lst.Add(new Breed { Name = "Field Spaniel                         " });
            lst.Add(new Breed { Name = "Fila Brasileiro                       " });
            lst.Add(new Breed { Name = "Finnish Hound                         " });
            lst.Add(new Breed { Name = "Finnish Lapphund                      " });
            lst.Add(new Breed { Name = "Finnish Spitz                         " });
            lst.Add(new Breed { Name = "Flat - Coated Retriever               " });
            lst.Add(new Breed { Name = "Fox Terrier, Smooth                   " });
            lst.Add(new Breed { Name = "Fox Terrier, Wire                     " });
            lst.Add(new Breed { Name = "French Brittany                       " });
            lst.Add(new Breed { Name = "French Bulldog                        " });
            lst.Add(new Breed { Name = "French Spaniel                        " });
            lst.Add(new Breed { Name = "Gaddi Kutta                           " });
            lst.Add(new Breed { Name = "Galgo Español                         " });
            lst.Add(new Breed { Name = "Galician Shepherd Dog                 " });
            lst.Add(new Breed { Name = "Garafian Shepherd                     " });
            lst.Add(new Breed { Name = "Gascon Saintongeois                   " });
            lst.Add(new Breed { Name = "Georgian Shepherd                     " });
            lst.Add(new Breed { Name = "German Longhaired Pointer             " });
            lst.Add(new Breed { Name = "German Pinscher                       " });
            lst.Add(new Breed { Name = "German Roughhaired Pointer            " });
            lst.Add(new Breed { Name = "German Shepherd Dog                   " });
            lst.Add(new Breed { Name = "German Shorthaired Pointer            " });
            lst.Add(new Breed { Name = "German Spaniel                        " });
            lst.Add(new Breed { Name = "German Spitz                          " });
            lst.Add(new Breed { Name = "German Wirehaired Pointer             " });
            lst.Add(new Breed { Name = "Giant Schnauzer                       " });
            lst.Add(new Breed { Name = "Glen of Imaal Terrier                 " });
            lst.Add(new Breed { Name = "Golden Retriever                      " });
            lst.Add(new Breed { Name = "Gordon Setter                         " });
            lst.Add(new Breed { Name = "Gran Mastín de Borínquen              " });
            lst.Add(new Breed { Name = "Grand Anglo - Français Blanc et Noir  " });
            lst.Add(new Breed { Name = "Grand Anglo - Français Blanc et Orange" });
            lst.Add(new Breed { Name = "Grand Anglo - Français Tricolore      " });
            lst.Add(new Breed { Name = "Grand Basset Griffon Vendéen          " });
            lst.Add(new Breed { Name = "Grand Bleu de Gascogne                " });
            lst.Add(new Breed { Name = "Grand Griffon Vendéen                 " });
            lst.Add(new Breed { Name = "Great Dane                            " });
            lst.Add(new Breed { Name = "Great Pyrenees                        " });
            lst.Add(new Breed { Name = "Greater Swiss Mountain Dog            " });
            lst.Add(new Breed { Name = "Greek Harehound                       " });
            lst.Add(new Breed { Name = "Greek Shepherd                        " });
            lst.Add(new Breed { Name = "Greenland Dog                         " });
            lst.Add(new Breed { Name = "Greyhound                             " });
            lst.Add(new Breed { Name = "Griffon Bleu de Gascogne              " });
            lst.Add(new Breed { Name = "Griffon Fauve de Bretagne             " });
            lst.Add(new Breed { Name = "Griffon Nivernais                     " });
            lst.Add(new Breed { Name = "Guatemalan Dogo                       " });
            lst.Add(new Breed { Name = "Gull Terrier                          " });
            lst.Add(new Breed { Name = "Hamiltonstövare                       " });
            lst.Add(new Breed { Name = "Hanover Hound                         " });
            lst.Add(new Breed { Name = "Hare Indian Dog                       " });
            lst.Add(new Breed { Name = "Harrier                               " });
            lst.Add(new Breed { Name = "Havanese                              " });
            lst.Add(new Breed { Name = "Hawaiian Poi Dog                      " });
            lst.Add(new Breed { Name = "Himalayan Sheepdog                    " });
            lst.Add(new Breed { Name = "Hokkaido                              " });
            lst.Add(new Breed { Name = "Hortaya borzaya                       " });
            lst.Add(new Breed { Name = "Hovawart                              " });
            lst.Add(new Breed { Name = "Huntaway                              " });
            lst.Add(new Breed { Name = "Hygen Hound                           " });
            lst.Add(new Breed { Name = "Ibizan Hound                          " });
            lst.Add(new Breed { Name = "Icelandic Sheepdog                    " });
            lst.Add(new Breed { Name = "Indian pariah dog                     " });
            lst.Add(new Breed { Name = "Indian Spitz                          " });
            lst.Add(new Breed { Name = "Irish Red and White Setter            " });
            lst.Add(new Breed { Name = "Irish Setter                          " });
            lst.Add(new Breed { Name = "Irish Terrier                         " });
            lst.Add(new Breed { Name = "Irish Water Spaniel                   " });
            lst.Add(new Breed { Name = "Irish Wolfhound                       " });
            lst.Add(new Breed { Name = "Istrian Coarse-haired Hound           " });
            lst.Add(new Breed { Name = "Istrian Short - haired Hound          " });
            lst.Add(new Breed { Name = "Italian Greyhound                     " });
            lst.Add(new Breed { Name = "Jack Russell Terrier                  " });
            lst.Add(new Breed { Name = "Jagdterrier                           " });
            lst.Add(new Breed { Name = "Swedish Elkhound                      " });
            lst.Add(new Breed { Name = "Japanese Chin                         " });
            lst.Add(new Breed { Name = "Japanese Spitz                        " });
            lst.Add(new Breed { Name = "Japanese Terrier                      " });
            lst.Add(new Breed { Name = "Jindo                                 " });
            lst.Add(new Breed { Name = "Jonangi                               " });
            lst.Add(new Breed { Name = "Kaikadi dog                           " });
            lst.Add(new Breed { Name = "Kai Ken                               " });
            lst.Add(new Breed { Name = "Kangal Shepherd Dog                   " });
            lst.Add(new Breed { Name = "Kanni                                 " });
            lst.Add(new Breed { Name = "Karakachan dog                        " });
            lst.Add(new Breed { Name = "Karelian Bear Dog                     " });
            lst.Add(new Breed { Name = "Karst Shepherd                        " });
            lst.Add(new Breed { Name = "Keeshond                              " });
            lst.Add(new Breed { Name = "Kerry Beagle                          " });
            lst.Add(new Breed { Name = "Kerry Blue Terrier                    " });
            lst.Add(new Breed { Name = "King Charles Spaniel                  " });
            lst.Add(new Breed { Name = "King Shepherd                         " });
            lst.Add(new Breed { Name = "Kintamani                             " });
            lst.Add(new Breed { Name = "Kishu Ken                             " });
            lst.Add(new Breed { Name = "Komondor                              " });
            lst.Add(new Breed { Name = "Koolie                                " });
            lst.Add(new Breed { Name = "Koyun dog                             " });
            lst.Add(new Breed { Name = "Kromfohrländer                        " });
            lst.Add(new Breed { Name = "Kumaon Mastiff                        " });
            lst.Add(new Breed { Name = "Kunming Wolfdog                       " });
            lst.Add(new Breed { Name = "Kurī                                  " });
            lst.Add(new Breed { Name = "Kuvasz                                " });
            lst.Add(new Breed { Name = "Kyi - Leo                             " });
            lst.Add(new Breed { Name = "Labrador Husky                        " });
            lst.Add(new Breed { Name = "Labrador Retriever                    " });
            lst.Add(new Breed { Name = "Lagotto Romagnolo                     " });
            lst.Add(new Breed { Name = "Lakeland Terrier                      " });
            lst.Add(new Breed { Name = "Lancashire Heeler                     " });
            lst.Add(new Breed { Name = "Landseer                              " });
            lst.Add(new Breed { Name = "Lapponian Herder                      " });
            lst.Add(new Breed { Name = "Lapponian Shepherd                    " });
            lst.Add(new Breed { Name = "Leonberger                            " });
            lst.Add(new Breed { Name = "Lhasa Apso                            " });
            lst.Add(new Breed { Name = "Lithuanian Hound                      " });
            lst.Add(new Breed { Name = "Louisiana Catahoula Leopard Dog       " });
            lst.Add(new Breed { Name = "Löwchen                               " });
            lst.Add(new Breed { Name = "Mackenzie River husky                 " });
            lst.Add(new Breed { Name = "Magyar agár                           " });
            lst.Add(new Breed { Name = "Mahratta Greyhound                    " });
            lst.Add(new Breed { Name = "Maltese                               " });
            lst.Add(new Breed { Name = "Manchester Terrier                    " });
            lst.Add(new Breed { Name = "Maremma Sheepdog                      " });
            lst.Add(new Breed { Name = "Marquesan Dog                         " });
            lst.Add(new Breed { Name = "McNab dog                             " });
            lst.Add(new Breed { Name = "Miniature American Shepherd           " });
            lst.Add(new Breed { Name = "Miniature Bull Terrier                " });
            lst.Add(new Breed { Name = "Miniature Fox Terrier                 " });
            lst.Add(new Breed { Name = "Miniature Pinscher                    " });
            lst.Add(new Breed { Name = "Miniature Schnauzer                   " });
            lst.Add(new Breed { Name = "Miniature Shar Pei                    " });
            lst.Add(new Breed { Name = "Molossus                              " });
            lst.Add(new Breed { Name = "Molossus of Epirus                    " });
            lst.Add(new Breed { Name = "Montenegrin Mountain Hound            " });
            lst.Add(new Breed { Name = "Moscow Watchdog                       " });
            lst.Add(new Breed { Name = "Moscow Water Dog                      " });
            lst.Add(new Breed { Name = "Mountain Cur                          " });
            lst.Add(new Breed { Name = "Mucuchies                             " });
            lst.Add(new Breed { Name = "Mudhol Hound                          " });
            lst.Add(new Breed { Name = "Mudi                                  " });
            lst.Add(new Breed { Name = "Münsterländer, Large                  " });
            lst.Add(new Breed { Name = "Münsterländer, Small                  " });
            lst.Add(new Breed { Name = "Neapolitan Mastiff                    " });
            lst.Add(new Breed { Name = "Nederlandse Kooikerhondje             " });
            lst.Add(new Breed { Name = "Newfoundland                          " });
            lst.Add(new Breed { Name = "New Zealand Heading Dog               " });
            lst.Add(new Breed { Name = "Norfolk Spaniel                       " });
            lst.Add(new Breed { Name = "Norfolk Terrier                       " });
            lst.Add(new Breed { Name = "Norrbottenspets                       " });
            lst.Add(new Breed { Name = "North Country Beagle                  " });
            lst.Add(new Breed { Name = "Northern Inuit Dog                    " });
            lst.Add(new Breed { Name = "Norwegian Buhund                      " });
            lst.Add(new Breed { Name = "Norwegian Elkhound                    " });
            lst.Add(new Breed { Name = "Norwegian Lundehund                   " });
            lst.Add(new Breed { Name = "Norwich Terrier                       " });
            lst.Add(new Breed { Name = "Nova Scotia Duck Tolling Retriever    " });
            lst.Add(new Breed { Name = "Old Croatian Sighthound               " });
            lst.Add(new Breed { Name = "Old Danish Pointer                    " });
            lst.Add(new Breed { Name = "Old English Bulldog                   " });
            lst.Add(new Breed { Name = "Old English Sheepdog                  " });
            lst.Add(new Breed { Name = "Old English Terrier                   " });
            lst.Add(new Breed { Name = "Old German Shepherd Dog               " });
            lst.Add(new Breed { Name = "Old Spanish Pointer                   " });
            lst.Add(new Breed { Name = "Old Time Farm Shepherd                " });
            lst.Add(new Breed { Name = "Olde English Bulldogge                " });
            lst.Add(new Breed { Name = "Otterhound                            " });
            lst.Add(new Breed { Name = "Pachon Navarro                        " });
            lst.Add(new Breed { Name = "Pandikona                             " });
            lst.Add(new Breed { Name = "Paisley Terrier                       " });
            lst.Add(new Breed { Name = "Papillon                              " });
            lst.Add(new Breed { Name = "Parson Russell Terrier                " });
            lst.Add(new Breed { Name = "Pastore della Lessinia e del Lagorai  " });
            lst.Add(new Breed { Name = "Patterdale Terrier                    " });
            lst.Add(new Breed { Name = "Pekingese                             " });
            lst.Add(new Breed { Name = "Perro de Pastor Mallorquin            " });
            lst.Add(new Breed { Name = "Perro de Presa Canario                " });
            lst.Add(new Breed { Name = "Perro de Presa Mallorquin             " });
            lst.Add(new Breed { Name = "Peruvian Inca Orchid                  " });
            lst.Add(new Breed { Name = "Petit Basset Griffon Vendéen          " });
            lst.Add(new Breed { Name = "Petit Bleu de Gascogne                " });
            lst.Add(new Breed { Name = "Phalène                               " });
            lst.Add(new Breed { Name = "Pharaoh Hound                         " });
            lst.Add(new Breed { Name = "Phu Quoc Ridgeback                    " });
            lst.Add(new Breed { Name = "Picardy Spaniel                       " });
            lst.Add(new Breed { Name = "Plummer Terrier                       " });
            lst.Add(new Breed { Name = "Plott Hound                           " });
            lst.Add(new Breed { Name = "Podenco Canario                       " });
            lst.Add(new Breed { Name = "Poitevin                              " });
            lst.Add(new Breed { Name = "Polish Greyhound                      " });
            lst.Add(new Breed { Name = "Polish Hound                          " });
            lst.Add(new Breed { Name = "Polish Hunting Dog                    " });
            lst.Add(new Breed { Name = "Polish Lowland Sheepdog               " });
            lst.Add(new Breed { Name = "Polish Tatra Sheepdog                 " });
            lst.Add(new Breed { Name = "Pomeranian                            " });
            lst.Add(new Breed { Name = "Pont - Audemer Spaniel                " });
            lst.Add(new Breed { Name = "Poodle                                " });
            lst.Add(new Breed { Name = "Porcelaine                            " });
            lst.Add(new Breed { Name = "Portuguese Podengo                    " });
            lst.Add(new Breed { Name = "Portuguese Pointer                    " });
            lst.Add(new Breed { Name = "Portuguese Water Dog                  " });
            lst.Add(new Breed { Name = "Posavac Hound                         " });
            lst.Add(new Breed { Name = "Potsdam Greyhound                     " });
            lst.Add(new Breed { Name = "Pražský Krysařík                      " });
            lst.Add(new Breed { Name = "Pudelpointer                          " });
            lst.Add(new Breed { Name = "Pug                                   " });
            lst.Add(new Breed { Name = "Puli                                  " });
            lst.Add(new Breed { Name = "Pumi                                  " });
            lst.Add(new Breed { Name = "Pungsan dog                           " });
            lst.Add(new Breed { Name = "Pyrenean Mastiff                      " });
            lst.Add(new Breed { Name = "Pyrenean Shepherd                     " });
            lst.Add(new Breed { Name = "Rafeiro do Alentejo                   " });
            lst.Add(new Breed { Name = "Rajapalayam                           " });
            lst.Add(new Breed { Name = "Rampur Greyhound                      " });
            lst.Add(new Breed { Name = "Rastreador Brasileiro                 " });
            lst.Add(new Breed { Name = "Rat Terrier                           " });
            lst.Add(new Breed { Name = "Ratonero Bodeguero Andaluz            " });
            lst.Add(new Breed { Name = "Ratonero Mallorquin                   " });
            lst.Add(new Breed { Name = "Ratonero Murciano de Huerta           " });
            lst.Add(new Breed { Name = "Ratonero Valenciano                   " });
            lst.Add(new Breed { Name = "Redbone Coonhound                     " });
            lst.Add(new Breed { Name = "Rhodesian Ridgeback                   " });
            lst.Add(new Breed { Name = "Romanian Mioritic Shepherd Dog        " });
            lst.Add(new Breed { Name = "Romanian Raven Shepherd Dog           " });
            lst.Add(new Breed { Name = "Rottweiler                            " });
            lst.Add(new Breed { Name = "Russian Salon Dog                     " });
            lst.Add(new Breed { Name = "Russian Spaniel                       " });
            lst.Add(new Breed { Name = "Russian Toy                           " });
            lst.Add(new Breed { Name = "Russian Tracker                       " });
            lst.Add(new Breed { Name = "Russo - European Laika                " });
            lst.Add(new Breed { Name = "Russell Terrier                       " });
            lst.Add(new Breed { Name = "Saarloos Wolfdog                      " });
            lst.Add(new Breed { Name = "Sabueso Español                       " });
            lst.Add(new Breed { Name = "Sabueso fino Colombiano               " });
            lst.Add(new Breed { Name = "Saint Bernard                         " });
            lst.Add(new Breed { Name = "Saint John's water dog                " });
            lst.Add(new Breed { Name = "Saint - Usuge Spaniel                 " });
            lst.Add(new Breed { Name = "Sakhalin Husky                        " });
            lst.Add(new Breed { Name = "Salish Wool Dog                       " });
            lst.Add(new Breed { Name = "Saluki                                " });
            lst.Add(new Breed { Name = "Samoyed                               " });
            lst.Add(new Breed { Name = "Sapsali                               " });
            lst.Add(new Breed { Name = "Šarplaninac                           " });
            lst.Add(new Breed { Name = "Schapendoes                           " });
            lst.Add(new Breed { Name = "Schillerstövare                       " });
            lst.Add(new Breed { Name = "Schipperke                            " });
            lst.Add(new Breed { Name = "Schweizer Laufhund                    " });
            lst.Add(new Breed { Name = "Schweizerischer Niederlaufhund        " });
            lst.Add(new Breed { Name = "Scotch Collie                         " });
            lst.Add(new Breed { Name = "Scottish Deerhound                    " });
            lst.Add(new Breed { Name = "Scottish Terrier                      " });
            lst.Add(new Breed { Name = "Sealyham Terrier                      " });
            lst.Add(new Breed { Name = "Segugio Italiano                      " });
            lst.Add(new Breed { Name = "Seppala Siberian Sleddog              " });
            lst.Add(new Breed { Name = "Serbian Hound                         " });
            lst.Add(new Breed { Name = "Serbian Tricolour Hound               " });
            lst.Add(new Breed { Name = "Seskar Seal Dog                       " });
            lst.Add(new Breed { Name = "Shar Pei                              " });
            lst.Add(new Breed { Name = "Shetland Sheepdog                     " });
            lst.Add(new Breed { Name = "Shiba Inu                             " });
            lst.Add(new Breed { Name = "Shih Tzu                              " });
            lst.Add(new Breed { Name = "Shikoku                               " });
            lst.Add(new Breed { Name = "Shiloh Shepherd                       " });
            lst.Add(new Breed { Name = "Siberian Husky                        " });
            lst.Add(new Breed { Name = "Silken Windhound                      " });
            lst.Add(new Breed { Name = "Silky Terrier                         " });
            lst.Add(new Breed { Name = "Sinhala Hound                         " });
            lst.Add(new Breed { Name = "Skye Terrier                          " });
            lst.Add(new Breed { Name = "Sloughi                               " });
            lst.Add(new Breed { Name = "Slovak Cuvac                          " });
            lst.Add(new Breed { Name = "Slovakian Wirehaired Pointer          " });
            lst.Add(new Breed { Name = "Slovenský kopov                       " });
            lst.Add(new Breed { Name = "Smålandsstövare                       " });
            lst.Add(new Breed { Name = "Small Greek Domestic Dog              " });
            lst.Add(new Breed { Name = "Soft - Coated Wheaten Terrier         " });
            lst.Add(new Breed { Name = "South Russian Ovcharka                " });
            lst.Add(new Breed { Name = "Southern Hound                        " });
            lst.Add(new Breed { Name = "Spanish Mastiff                       " });
            lst.Add(new Breed { Name = "Spanish Water Dog                     " });
            lst.Add(new Breed { Name = "Spinone Italiano                      " });
            lst.Add(new Breed { Name = "Sporting Lucas Terrier                " });
            lst.Add(new Breed { Name = "Stabyhoun                             " });
            lst.Add(new Breed { Name = "Staffordshire Bull Terrier            " });
            lst.Add(new Breed { Name = "Standard Schnauzer                    " });
            lst.Add(new Breed { Name = "Stephens Cur                          " });
            lst.Add(new Breed { Name = "Styrian Coarse - haired Hound         " });
            lst.Add(new Breed { Name = "Sussex Spaniel                        " });
            lst.Add(new Breed { Name = "Swedish Lapphund                      " });
            lst.Add(new Breed { Name = "Swedish Vallhund                      " });
            lst.Add(new Breed { Name = "Tahitian Dog                          " });
            lst.Add(new Breed { Name = "Tahltan Bear Dog                      " });
            lst.Add(new Breed { Name = "Taigan                                " });
            lst.Add(new Breed { Name = "Taiwan Dog                            " });
            lst.Add(new Breed { Name = "Talbot Hound                          " });
            lst.Add(new Breed { Name = "Tamaskan Dog                          " });
            lst.Add(new Breed { Name = "Teddy Roosevelt Terrier               " });
            lst.Add(new Breed { Name = "Telomian                              " });
            lst.Add(new Breed { Name = "Tenterfield Terrier                   " });
            lst.Add(new Breed { Name = "Terceira Mastiff                      " });
            lst.Add(new Breed { Name = "Thai Bangkaew Dog                     " });
            lst.Add(new Breed { Name = "Thai Ridgeback                        " });
            lst.Add(new Breed { Name = "Tibetan Mastiff                       " });
            lst.Add(new Breed { Name = "Tibetan Spaniel                       " });
            lst.Add(new Breed { Name = "Tibetan Terrier                       " });
            lst.Add(new Breed { Name = "Tornjak                               " });
            lst.Add(new Breed { Name = "Tosa                                  " });
            lst.Add(new Breed { Name = "Toy Bulldog                           " });
            lst.Add(new Breed { Name = "Toy Fox Terrier                       " });
            lst.Add(new Breed { Name = "Toy Manchester Terrier                " });
            lst.Add(new Breed { Name = "Toy Trawler Spaniel                   " });
            lst.Add(new Breed { Name = "Transylvanian Hound                   " });
            lst.Add(new Breed { Name = "Treeing Cur                           " });
            lst.Add(new Breed { Name = "Treeing Tennessee Brindle             " });
            lst.Add(new Breed { Name = "Treeing Walker Coonhound              " });
            lst.Add(new Breed { Name = "Trigg Hound                           " });
            lst.Add(new Breed { Name = "Tweed Water Spaniel                   " });
            lst.Add(new Breed { Name = "Tyrolean Hound                        " });
            lst.Add(new Breed { Name = "Cimarrón Uruguayo                     " });
            lst.Add(new Breed { Name = "Vanjari Hound                         " });
            lst.Add(new Breed { Name = "Villano de Las Encartaciones          " });
            lst.Add(new Breed { Name = "Villanuco de Las Encartaciones        " });
            lst.Add(new Breed { Name = "Vizsla                                " });
            lst.Add(new Breed { Name = "Volpino Italiano                      " });
            lst.Add(new Breed { Name = "Weimaraner                            " });
            lst.Add(new Breed { Name = "Welsh Corgi, Cardigan                 " });
            lst.Add(new Breed { Name = "Welsh Corgi, Pembroke                 " });
            lst.Add(new Breed { Name = "Welsh Sheepdog                        " });
            lst.Add(new Breed { Name = "Welsh Springer Spaniel                " });
            lst.Add(new Breed { Name = "Welsh Terrier                         " });
            lst.Add(new Breed { Name = "West Highland White Terrier           " });
            lst.Add(new Breed { Name = "West Siberian Laika                   " });
            lst.Add(new Breed { Name = "Westphalian Dachsbracke               " });
            lst.Add(new Breed { Name = "Wetterhoun                            " });
            lst.Add(new Breed { Name = "Whippet                               " });
            lst.Add(new Breed { Name = "White Shepherd                        " });
            lst.Add(new Breed { Name = "Wirehaired Pointing Griffon           " });
            lst.Add(new Breed { Name = "Wirehaired Vizsla                     " });
            lst.Add(new Breed { Name = "Xiasi Dog                             " });
            lst.Add(new Breed { Name = "Xoloitzcuintli                        " });
            lst.Add(new Breed { Name = "Yakutian Laika                        " });
            lst.Add(new Breed { Name = "Yorkshire Terrier                     " });
            return lst;
        }

        private List<Pet> LotOfPetsList()
        {
            var lst = new List<Pet>();

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "1.jpg");
            lst.Add(new Pet { Id = 1, BreedId = 223, Name = "Archie", UserId = 1, Age = 3, GenderId = 1, ImagePath = filePath, AncestryId = 1, BreederId = 1 });
            lst.Add(new Pet { Id = 2, BreedId = 223, Name = "Bailey", UserId = 1, Age = 4, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 3, BreedId = 223, Name = "George", UserId = 1, Age = 5, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 4, BreedId = 223, Name = "Gus", UserId = 1, Age = 6, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 5, BreedId = 223, Name = "Hunter", UserId = 1, Age = 7, GenderId = 1, ImagePath = filePath, AncestryId = 2 });
            lst.Add(new Pet { Id = 6, BreedId = 223, Name = "Rudy", UserId = 1, Age = 1, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 7, BreedId = 223, Name = "Jake", UserId = 1, Age = 2, GenderId = 1, ImagePath = filePath });
            
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "6.jpg");
            lst.Add(new Pet { Id = 8, BreedId = 223, Name = "Austin", UserId = 2, Age = 3, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 9, BreedId = 223, Name = "Bandit", UserId = 2, Age = 4, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 10, BreedId = 223, Name = "Baron", UserId = 2, Age = 5, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 11, BreedId = 223, Name = "Bear", UserId = 2, Age = 6, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 12, BreedId = 223, Name = "Brady", UserId = 2, Age = 7, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 13, BreedId = 223, Name = "Captain", UserId = 2, Age = 1, GenderId = 1, ImagePath = filePath });
            lst.Add(new Pet { Id = 14, BreedId = 223, Name = "Chester", UserId = 2, Age = 2, GenderId = 1, ImagePath = filePath });

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "5.jpg");
            lst.Add(new Pet { Id = 15, BreedId = 223, Name = "Abby", UserId = 1, Age = 4, GenderId = 2, ImagePath = filePath });
            lst.Add(new Pet { Id = 16, BreedId = 223, Name = "Amelia", UserId = 1, Age = 5, GenderId = 2, ImagePath = filePath });
            lst.Add(new Pet { Id = 17, BreedId = 223, Name = "Adeline", UserId = 1, Age = 6, GenderId = 2, ImagePath = filePath, AncestryId = 3 });
            lst.Add(new Pet { Id = 18, BreedId = 223, Name = "Oreo", UserId = 1, Age = 7, GenderId = 2, ImagePath = filePath, AncestryId = 4 });

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles", "7.jpg");
            lst.Add(new Pet { Id = 19, BreedId = 223, Name = "Destiny", UserId = 2, Age = 4, GenderId = 2, ImagePath = filePath });
            lst.Add(new Pet { Id = 20, BreedId = 223, Name = "Eva", UserId = 2, Age = 5, GenderId = 2, ImagePath = filePath });
            lst.Add(new Pet { Id = 21, BreedId = 223, Name = "Goldie", UserId = 2, Age = 6, GenderId = 2, ImagePath = filePath });
            lst.Add(new Pet { Id = 22, BreedId = 223, Name = "Jessie", UserId = 2, Age = 7, GenderId = 2, ImagePath = filePath });

            return lst;
        }

        private List<Show> ShowsList()
        {
            var lst = new List<Show>();

            lst.Add(new Show()
            {
                Id = 1,
                Name = "Kharkiv Winter Cup 2019",
                Date = DateTime.Parse("26.01.2019"),
                City = "Kharkiv",
                Country = "Ukraine",
                Duration = 2,
                Sponsor = "Харківський МО «Природа», ВГО «КСУ»",
                ContactEmail = "Kharkovpriroda@ukr.net",
                ContactPhone = "057 705 17 98"
            });

            lst.Add(new Show()
            {
                Id = 2,
                Name = "Пам’яті Ольги Низової",
                Date = DateTime.Parse("26.01.2019"),
                City = "Lviv",
                Country = "Ukraine",
                Duration = 2,
                Sponsor = "Львівський МО, «ЛВ Фортуна», ВГО «КСУ»",
                ContactEmail = "ksulviv.fortuna@gmail.com",
                ContactPhone = "+38 (032) 238-09-84"
            });

            lst.Add(new Show()
            {
                Id = 3,
                Name = "САС",
                Date = DateTime.Parse("04.05.2019"),
                City = "Kharkiv",
                Country = "Ukraine",
                Duration = 2,
                Sponsor = "Харківський РО ВГО «КСУ» в Харківській області, «Союз - Віват»",
                ContactEmail = "souzvivat@i.ua",
                ContactPhone = "+38 (057) 757-26-27"
            });

            lst.Add(new Show()
            {
                Id = 4,
                Name = "FCI-CACIB",
                Date = DateTime.Parse("11.05.2019"),
                City = "Mariupil",
                Country = "Ukraine",
                Duration = 1,
                Sponsor = "Маріупольський МО ВГО «КСУ», «Кінологічний центр Азов»",
                ContactEmail = "moksuazov@gmail.com",
                ContactPhone = "+38 (050) 656-08-48"
            });


            return lst;
        }
    }
}