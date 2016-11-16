using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using FifaFanApp.Models;

namespace FifaFanApp.DAL
{
   
        public class FifaRepository
        {
            private FifaDbContext db = new FifaDbContext();

            public void SaveClubInfo(FifaClub obj)
            {
                if (!CheckNationOrClubExistance(obj.ClubName, "Club"))
                {
                    try
                    {
                        db.FifaClubs.Add(obj);
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        // Retrieve the error messages as a list of strings.
                        var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);

                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                            fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    }

                }
            }


            public void SaveNationInfo(FifaNation obj)
            {
                try
                {
                    if (!CheckNationOrClubExistance(obj.NationName, "Nation"))
                    {
                    db.FifaNations.Add(obj);
                    db.SaveChanges();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
        }


            private bool CheckNationOrClubExistance(string nationOrClub, string choice)
            {
                if (choice == "Nation")
                {
                return (db.FifaNations.Any(u => u.NationName == nationOrClub));
                }
                return (db.FifaClubs.Any(u => u.ClubName == nationOrClub));
            }
        }
    }
