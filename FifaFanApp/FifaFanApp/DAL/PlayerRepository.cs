using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using FifaFanApp.Helpers;
using FifaFanApp.Models;

namespace FifaFanApp.DAL
{
    public class PlayerRepository
    {
        private FifaDbContext db = new FifaDbContext();
        public enum SortCategories
        {
            Rating = 1,
            Worth = 2,
            Speed = 3,
            Shooting = 4,
            Dribble = 5,
            Defender = 6,
            Strongest = 7
        };
        /// <summary>
        /// Retrieve the players by a sort filter and limiting the amount we take by
        /// calling paging extention method
        /// </summary>
        /// <param name="sortChoice"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Player> SortPlayerBy(int sortChoice, int pageNumber, int pageSize, out int count)
        {
           IQueryable<Player> query;
           SortCategories category = (SortCategories)sortChoice;
            switch (category)
            {
                case SortCategories.Rating:
                    query = db.Players.OrderByDescending(x => x.Rating.Overall).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Worth:
                    query = db.Players.OrderByDescending(x => x.MaxWorth).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Speed:
                    query = db.Players.OrderByDescending(x => x.Rating.Pace).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Shooting:
                    query = db.Players.OrderByDescending(x => x.Rating.Shooting).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Dribble:
                    query = db.Players.OrderByDescending(x => x.Rating.Dribbling).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Defender:
                    query =  db.Players.OrderByDescending(x => x.Rating.Defense).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                case SortCategories.Strongest:
                    query = db.Players.OrderByDescending(x => x.Rating.Physical).Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
                default:
                    query = db.Players.Include(r => r.Rating).Include(i => i.Image);
                    count = query.Count();
                    return query.Page(pageNumber, pageSize).ToList();
            }
        }

        /// <summary>
        /// retrieves all players 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Player> GetAllPlayers(int pageNumber, int pageSize, out int count)
        {
            var query = db.Players.OrderByDescending(x => x.Rating.Overall).Include(r => r.Rating).Include(i => i.Image);
            count = query.Count();
            return query.Page(pageNumber, pageSize).ToList();
        }
        public void AddPlayer(Player player)
        {
            try
            {
                if (!PlayerExists(player.Name))
                {
                    db.Players.Add(player);
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
      
        /// <summary>
        /// club images and nation flags are preset in the database by path
        /// this method selects them from the database that matches 
        /// the player properties
        /// </summary>
        /// <param name="nation"></param>
        /// <param name="club"></param>
        /// <returns></returns>
        public Image GetClubAndNationImage(string nation, string club)
        {
            
            var results = (from L1 in db.FifaNations
                           from L2 in db.FifaClubs
                           where L1.NationName == nation && L2.ClubName == club
                           select new { L1.NationImagePath, L2.ClubImagePath }).Single();
            return new Image
            {
                ClubPath = results.ClubImagePath,
                NationalityPath = results.NationImagePath
            };
        }
        private bool PlayerExists(string name)
        {
            return db.Players.Any(x => x.Name.Equals(name));
        }

    }



}
