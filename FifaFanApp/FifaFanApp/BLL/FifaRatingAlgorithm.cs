using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using FifaFanApp.Models;

namespace FifaFanApp.BLL
{

    /// <summary>
    /// These methods calculate the overall player rating depending on there position.
    /// Some attributes stand out more for some positions than others
    /// 
    /// to that specific position
    /// </summary>
    public static class FifaRatingAlgorithm
    {
       
         static int CenterBack(int marking, int standingTackle, int slidingTackle, int headingAccuracy,
            int strength, int aggression, int interception, int shortPassing, int ballControl, int reactions, int jumping)
        {
            var overall = Math.Round(marking*0.15 + standingTackle*0.15 + slidingTackle*0.15 + headingAccuracy*0.1 +
                                     strength*0.1 + aggression*0.08 + interception*0.08 + shortPassing*0.05 +
                                     ballControl*0.05 + reactions*0.05 +
                                     jumping*0.04);
            return Convert.ToInt16(Math.Ceiling(overall)); 
        }

         static int FullBack(int slidingTackle, int standingTackle, int interception, int marking,
          int stamina, int reactions, int crossing, int headingAccuracy, int ballControl, int shortPassing, int sprintSpeed, int aggression)
        {
            var overall = Math.Round(slidingTackle * 0.13 + standingTackle * 0.12 + interception * 0.12 + marking * 0.10 +
                                     stamina * 0.08 + reactions * 0.08 + crossing * 0.07 + headingAccuracy * 0.07 +
                                     ballControl * 0.07 + shortPassing * 0.06 +
                                     sprintSpeed * 0.05 + aggression * 0.05);
            return Convert.ToInt16(Math.Ceiling(overall)); 
        }

         static int WideBack(int standingTackle, int slidingTackle, int crossing, int shortPassing,
  int ballControl, int interceptions, int marking, int stamina, int reactions, int dribbling, int sprintSpeed, int agility)
        {
            var overall = Math.Round(standingTackle * 0.11 + slidingTackle * 0.10 + crossing * 0.10 + shortPassing * 0.10 +
                                     ballControl * 0.10 + interceptions * 0.10 + marking * 0.09 + stamina * 0.08 +
                                     reactions * 0.08 + dribbling * 0.07 +
                                     sprintSpeed * 0.04 + agility * 0.03);
            return Convert.ToInt16(Math.Ceiling(overall));
        }

         static int CenterDefensiveMidfielder(int shortPassing, int interceptions, int longPassing, int marking,
int standingTackle, int ballControl, int reactions, int vision, int stamina, int strength, int agression)
        {
            var overall = Math.Round(shortPassing * 0.13 + interceptions * 0.13 + longPassing * 0.11 + marking * 0.10 +
                                     standingTackle * 0.10 + ballControl * 0.09 + reactions * 0.09 + vision * 0.08 +
                                     stamina * 0.06 + strength * 0.06 +
                                     agression * 0.05);
            return Convert.ToInt16(Math.Ceiling(overall));
        }

         static int CenterMiddle(int shortPassing, int longPassing, int vision, int ballControl,
int dribbling, int reactions, int interceptions, int positioning, int standingTackle, int stamina, int longShots)
        {
            var overall = Math.Round(shortPassing * 0.15 + longPassing * 0.13 + vision * 0.12 + ballControl * 0.10 +
                                     dribbling * 0.09 + reactions * 0.08 + interceptions * 0.08 + positioning * 0.08 +
                                     standingTackle * 0.06 + stamina * 0.06 +
                                     longShots * 0.05);
            return Convert.ToInt16(Math.Ceiling(overall));
        }

         static int LeftMiddleRightMiddle(int crossing, int dribbling, int shortPassing, int ballControl,
int longPassing, int vision, int reactions, int positioning, int stamina, int acceleration, int sprintSpeed, int agility)
        {
            var overall = Math.Round(crossing * 0.14 + dribbling * 0.14 + shortPassing * 0.12 + ballControl * 0.12 +
                                     longPassing * 0.08 + vision * 0.08 + reactions *0.07 + positioning * 0.07
                                     + stamina * 0.05 + acceleration * 0.05 + sprintSpeed * 0.05 +
                                     agility * 0.03);
            return Convert.ToInt16(Math.Ceiling(overall));
        }


         static int CenteralAttackingMidfielder(int shortPassing, int vision, int ballControl, 
int positioning, int dribbling, int reactions, int longShots, int finishing, int shotPower, int acceleration, int agility)
        {
            var overall = Math.Round(shortPassing * 0.16 + vision * 0.16 + ballControl * 0.13 + positioning * 0.12 +
                                     dribbling * 0.11 + reactions * 0.08 + longShots * 0.06 + finishing * 0.05
                                     + shotPower * 0.05 + acceleration * 0.04 + agility * 0.04);
            return Convert.ToInt16(Math.Ceiling(overall));
        }


         static int LeftWingRightWing(int crossing, int dribbling, int ballControl,
int shortPassing, int positioning, int acceleration, int sprintSpeed, int reactions, int agility, int vision, 
int finishing, int longShots )
        {
            var overall = Math.Round(crossing * 0.16 + dribbling * 0.16 + ballControl * 0.13 + shortPassing * 0.10 +
                                     positioning * 0.09 + acceleration * 0.06 + sprintSpeed * 0.06 + reactions * 0.06
                                     + agility * 0.05 + vision * 0.05 + finishing * 0.04 + longShots * 0.04);
            return Convert.ToInt16(Math.Ceiling(overall));
        }


         static int LeftFieldCenterFieldRightField(int finishing, int positioning, int dribbling,
int ballControl, int shotPower, int longShots, int reactions, int shortPassing, int headingAccuracy, int vision,
int acceleration, int sprintSpeed)
        {
            var overall = Math.Round(finishing * 0.12 + positioning * 0.12 + dribbling * 0.11 + ballControl * 0.11 +
                                     shotPower * 0.10 + longShots * 0.10 + reactions * 0.10 + shortPassing * 0.06
                                     + headingAccuracy * 0.05 + vision * 0.05 + acceleration * 0.04 +
                                     sprintSpeed * 0.04);
            return Convert.ToInt16(Math.Ceiling(overall));
        }


         static int Striker(int finishing, int positioning, int headingAccuracy,
int shotPower, int reactions, int dribbling, int ballControl, int volleys, int longShots, int acceleration,
int sprintSpeed, int strength)
        {
            var overall = Math.Round(finishing * 0.20 + positioning * 0.12 + headingAccuracy * 0.10 + shotPower * 0.10 +
                                     reactions * 0.10 + dribbling * 0.08 + ballControl * 0.08 + volleys * 0.05
                                     + longShots * 0.05 + acceleration * 0.05 + sprintSpeed * 0.04 +
                                     strength * 0.03);
            return Convert.ToInt16(Math.Ceiling(overall));
        }

        static int Pace(int sprintSpeed, int acceleration)
        {
            var overallPace = Math.Round(sprintSpeed*0.55 + acceleration*0.45 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallPace));
        }


        static int Shooting(int finishing, int longShots, int shotPower, int positioning,int penalties, int volleys)
        {
            var overallShooting = Math.Round(finishing*0.45 + longShots * 0.02 + shotPower * 0.02 + positioning * 0.05
                 + volleys * 0.05 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallShooting));
        }

         static int Passing(int shortPassing, int vision, int crossing, int longPassing, int curve, int freeKickAccuracy)
        {
            var overallPassing = Math.Round(shortPassing * 0.35 + vision * 0.2 + crossing * 0.2 + longPassing * 0.15 + curve * 0.05
                 + freeKickAccuracy * 0.05 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallPassing));
        }


         static int Dribbling(int dribbling, int ballControl, int agility, int balance)
        {
            var overallDribbling = Math.Round(dribbling * 0.5 + ballControl * 0.35 + agility * 0.1 + balance * 0.05 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallDribbling));
        }


         static int Defense(int marking, int standingTackle, int interception, int headingAccuracy, int slidingTackle)
        {
            var overallDefense = Math.Round(marking * 0.3 + standingTackle * 0.3 + interception * 0.2 + headingAccuracy * 0.1 + headingAccuracy * 0.1 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallDefense));
        }


         static int Physical(int strength, int stamina, int agression, int jumping)
        {
            var overallPhysical = Math.Round(strength * 0.5 + stamina * 0.25 + agression * 0.2 + jumping * 0.05 - 0.01);
            return Convert.ToInt16(Math.Ceiling(overallPhysical));
        }


        /// <summary>
        /// 
        /// Fifa uses a data structure to rate there players
        /// The rating depends on the player position and what attributes mean most
        /// to that specific position
        /// 
        /// </summary>
        /// <param name="skillObj"></param>
        /// <param name="playerPosition"></param>
        /// <returns></returns>
        public static Rating CalculateRating(Skill skillObj, string playerPosition)
        {
            var overall = 0;
            switch (playerPosition)
            {
                case "CB":
                  overall = CenterBack(skillObj.Marking, skillObj.StandingTackle, skillObj.SlidingTackle,
                        skillObj.HeadingAccuracy, skillObj.Strength, skillObj.Aggression, skillObj.Interceptions,
                        skillObj.ShortPassing, skillObj.BallControl, skillObj.Reactions, skillObj.Jumping);
                    break;
                case "FB":
                    overall = FullBack(skillObj.SlidingTackle, skillObj.StandingTackle, skillObj.Interceptions,
                        skillObj.Marking,skillObj.Stamina, skillObj.Reactions, skillObj.Crossing, skillObj.HeadingAccuracy,
                        skillObj.BallControl, skillObj.ShortPassing,skillObj.SprintSpeed, skillObj.Aggression);
                    break;
                case "WB":
                    overall = WideBack(skillObj.StandingTackle, skillObj.SlidingTackle, skillObj.Crossing,
                        skillObj.ShortPassing, skillObj.BallControl, skillObj.Interceptions, skillObj.Marking,
                        skillObj.Stamina, skillObj.Reactions, skillObj.Dribbling, skillObj.SprintSpeed, skillObj.Agility);
                    break;
                case "CDM":
                    overall = CenterDefensiveMidfielder(skillObj.ShortPassing, skillObj.Interceptions,
                        skillObj.LongPassing, skillObj.Marking, skillObj.StandingTackle, skillObj.BallControl,
                        skillObj.Reactions, skillObj.Vision, skillObj.Stamina, skillObj.Strength, skillObj.Aggression);
                    break;
                case "CM":
                    overall = CenterMiddle(skillObj.ShortPassing, skillObj.LongPassing, skillObj.Vision,
                        skillObj.BallControl, skillObj.Dribbling, skillObj.Reactions, skillObj.Interceptions,
                        skillObj.Positioning, skillObj.StandingTackle, skillObj.Stamina, skillObj.LongShots);
                    break;
                case "LM":
                case "RM":
                    overall = LeftMiddleRightMiddle(skillObj.Crossing, skillObj.Dribbling, skillObj.ShortPassing,
                        skillObj.BallControl, skillObj.LongPassing, skillObj.Vision, skillObj.Reactions,
                        skillObj.Positioning, skillObj.Stamina, skillObj.Acceleration, skillObj.SprintSpeed,
                        skillObj.Agility);
                    break;
                case "CAM":
                    overall = CenteralAttackingMidfielder(skillObj.ShortPassing, skillObj.Vision, skillObj.BallControl,
                        skillObj.Positioning, skillObj.Dribbling, skillObj.Reactions, skillObj.LongShots,
                        skillObj.Finishing, skillObj.ShotPower, skillObj.Acceleration, skillObj.Agility);
                    break;
                case "LW":
                case "RW":
                    overall = LeftWingRightWing(skillObj.Crossing, skillObj.Dribbling, skillObj.BallControl,
                        skillObj.ShortPassing, skillObj.Positioning, skillObj.Acceleration, skillObj.SprintSpeed,
                        skillObj.Reactions, skillObj.Agility, skillObj.Vision, skillObj.Finishing, skillObj.LongShots);
                    break;
                case "LF":
                case "CF":
                case "RF":
                    overall = LeftFieldCenterFieldRightField(skillObj.Finishing, skillObj.Positioning,
                        skillObj.Dribbling, skillObj.BallControl, skillObj.ShotPower, skillObj.LongShots,
                        skillObj.Reactions, skillObj.ShortPassing, skillObj.HeadingAccuracy, skillObj.Vision,
                        skillObj.Acceleration, skillObj.SprintSpeed);
                    break;
                case "ST":
                    overall = Striker(skillObj.Finishing, skillObj.Positioning, skillObj.HeadingAccuracy,
                        skillObj.ShotPower, skillObj.Reactions, skillObj.Dribbling, skillObj.BallControl,
                        skillObj.Volleys, skillObj.LongShots, skillObj.Acceleration, skillObj.SprintSpeed,
                        skillObj.Strength);
                    break;
            }
            var pace = Pace(skillObj.SprintSpeed, skillObj.Acceleration);
            var shooting = Shooting(skillObj.Finishing, skillObj.LongShots, skillObj.ShotPower,
                skillObj.Positioning, skillObj.Penalties, skillObj.Volleys);
            var passing = Passing(skillObj.ShortPassing, skillObj.Vision, skillObj.Crossing, skillObj.LongPassing,
                skillObj.Curve, skillObj.FreeKick);
            var dribbling = Dribbling(skillObj.Dribbling, skillObj.BallControl, skillObj.Agility, skillObj.Balance);
            var defense = Defense(skillObj.Marking, skillObj.StandingTackle, skillObj.Interceptions,
                skillObj.HeadingAccuracy, skillObj.SlidingTackle);
            var physical = Physical(skillObj.Strength, skillObj.Stamina, skillObj.Aggression, skillObj.Jumping);
            var totalStats = pace + shooting + passing + dribbling + defense + physical;
            return new Rating {Overall = overall, Pace = pace, Defense = defense, Dribbling = dribbling, Passing = passing, Physical = physical, Shooting = shooting, TotalStats = totalStats };
        }

    }
}