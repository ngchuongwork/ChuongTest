using System;
using NUnit.Framework;

namespace ByteHRTest
{

    public class Program
    {
        public static double calculateLate(string shiftStart, string shiftEnd, string breakStart, string breakEnd, string signIn, string leaveFrom = null, string leaveTo = null)
        {
            double late = 0;
            DateTime s1Start = DateTime.ParseExact(shiftStart, "HH:mm", null);
            DateTime s1End = DateTime.ParseExact(breakStart, "HH:mm", null);
            DateTime s2Start = DateTime.ParseExact(breakEnd, "HH:mm", null);
            DateTime s2End = DateTime.ParseExact(shiftEnd, "HH:mm", null);
            DateTime check = DateTime.ParseExact(signIn, "HH:mm", null);
            DateTime lvFrom;
            DateTime lvTo;
            double shift1 = 0;
            double shift2 = 0;

            //timeframe in 2 days
            if (s1Start > s2End) s2End = s2End.AddDays(1);
            if (s1End > s2Start) s2Start = s2Start.AddDays(1);
            if (check > s2End) check = s2End;



            //in time
            if (check <= s1Start) return late;

            // leavetime
            if (leaveFrom != null && leaveTo != null)
            {
                lvFrom = DateTime.ParseExact(leaveFrom, "HH:mm", null);
                lvTo = DateTime.ParseExact(leaveTo, "HH:mm", null);
                if (lvFrom > lvTo) lvTo = lvTo.AddDays(1);
                if (lvFrom < s1Start) lvFrom = s1Start;
                if (lvTo > s2End) lvTo = s2End;

                //check leave in shift
                if (lvFrom <= s2End && lvTo >= s1Start)
                {
                   
                    // sign in shift 1 
                    if (check <= s1End)
                    {
                        
                        if (lvFrom == s1Start)
                        {
                            
                            if (lvTo < s1End)
                            {
                                if (check > lvTo) late = (check - lvTo).TotalMinutes ;
                            }
                        }
                        else if (lvFrom > s1Start)
                        {
                            

                            if (lvTo < s1End)
                            {
                                if (check <= lvFrom) late = (check - s1Start).TotalMinutes ;
                                else if (check >= lvTo) late = ((lvFrom - s1Start) + (check - lvTo)).TotalMinutes ;
                                else if (check >= lvFrom && check <= lvTo)
                                    late = (lvFrom - s1Start).TotalMinutes;
                            }
                            else
                            {
                                if (check < lvFrom) late = (check - s1Start).TotalMinutes ;
                                else late = (lvFrom - s1Start).TotalMinutes ;
                            }
                        }
                       
                    }
                    // sign in shift 2
                    else if (check >= s2Start)
                    {
                        
                        // caculate shift 1
                        if (lvFrom <= s1End)
                        {
                            
                            if (lvFrom == s1Start)
                            {
                                if (lvTo < s1End)
                                {
                                    shift1 = (s1End - lvTo).TotalMinutes;
                                }

                            }
                            else if (lvFrom > s1Start)
                            {
                               
                                if (lvTo < s1End)
                                {
                                    shift1 = (lvFrom - s1Start).TotalMinutes + (s1End - lvTo).TotalMinutes;
                                }
                                else
                                {
                                    shift1 = (lvFrom - s1Start).TotalMinutes;
                                }
                            }

                            //over break
                            if(lvTo >= s2Start) 
                            { 
                                
                                s2Start = lvTo;
                                if (check <= lvTo)
                                    shift2 = 0;
                                else
                                    shift2 = (check - s2Start).TotalMinutes;
                            }
                            else
                            {
                                shift2 = (check - s2Start).TotalMinutes;
                            }

                        }

                        //shift2
                        else
                        {
                            shift1 = (s1End - s1Start).TotalMinutes;
                            if (lvFrom == s2Start)
                            {
                                if (lvTo < s2End)
                                {
                                    if (check > lvTo) shift2 = (check - lvTo).TotalMinutes;
                                }
                            }
                            else if (lvFrom > s2Start)
                            {
                                
                                if (lvTo < s2End)
                                {
                                    if (check <= lvFrom) shift2 = (check - s2Start).TotalMinutes;
                                    else if (check >= lvTo) shift2 = ((lvFrom - s2Start) + (check - lvTo)).TotalMinutes;
                                    else if(check >= lvFrom && check <= lvTo) 
                                        shift2 = (lvFrom - s2Start).TotalMinutes;
                                }
                                else
                                {
                                    if (check < lvFrom) shift2 = (check - s2Start).TotalMinutes;
                                    else shift2 = (lvFrom - s2Start).TotalMinutes;
                                }
                            }
                            else
                            {
                                if (lvTo > s2Start)
                                {
                                    if (check <= lvFrom)
                                    {
                                        shift2 = (check - s2Start).TotalMinutes;
                                    }
                                    else if (check >= lvTo)
                                    {
                                        Console.WriteLine(111);
                                        shift2 = (check - lvTo).TotalMinutes;
                                    }
                                    else if (check >= lvFrom && check <= lvTo)
                                        shift2 = (lvFrom - s2Start).TotalMinutes;
                                }
                                else
                                {
                                    shift2 = (check - s2Start).TotalMinutes;
                                }

                            }
                        }

                        
                        late = (shift1 + shift2) ;
                    }
                    // break time
                    else if (check <= s2Start && check >= s1End)
                    {

                        
                        // caculate shift 1
                        if (lvFrom <= s1End)
                        {
                            if (lvFrom == s1Start)
                            {
                                if (lvTo < s1End)
                                {
                                    shift1 = (s1End - lvTo).TotalMinutes;
                                }

                            }
                            else if (lvFrom > s1Start)
                            {
                                if (lvTo < s1End)
                                {
                                    shift1 = (lvFrom - s1Start).TotalMinutes + (s1End - lvTo).TotalMinutes;
                                }
                                else
                                {
                                    shift1 = (lvFrom - s1Start).TotalMinutes;
                                }
                            }
                        }
                        late = shift1 ;
                    }
                    

                }
               
            }
            /// no leavetime
            else
            {
                // shift 1 
                if (check <= s1End) late = (check - s1Start).TotalMinutes ;
                // shift 2
                else if (check >= s2Start)
                    if (check <= s2End)
                    {
                        late = ((s1End - s1Start) + (check - s2Start)).TotalMinutes ;
                    }
                    else late = ((s1End - s1Start) + (s2End - s2Start)).TotalMinutes ;
                // break time
                else
                {
                    late = (s1End - s1Start).TotalMinutes ;
                }

            }
            return late;

        }
        public static void Main()
        {
            Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:30", "14:00");
            //#region không leave time
            //#region sign in ở ca 1 
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:15")); //15
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:15")); //240
            //#endregion

            //#region sign in ở ca 2
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:59")); // 239
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:40")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:15"));  //255
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "15:30"));  // 390
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:15"));
            //#region qua ngày
            ////Console.WriteLine(Program.calculateLate("19:00", "17:00", "20:00", "21:00", "20:30"));
            //#endregion
            //#endregion
            //#endregion

            //#region có leave time
            //#region leave time ở ca 1
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "08:00", "09:00")); //1
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "08:00", "09:00")); //0
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "08:00", "09:00")); //120
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "08:00", "09:00")); //180
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "08:00", "09:00")); //180
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "09:00")); //210
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "08:00", "09:00")); //420



            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "09:00", "10:00")); //60
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "09:00", "10:00")); //0
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "09:00", "10:00")); //30
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "09:00", "10:00")); //120
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "09:00", "10:00")); //180
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "09:00", "10:00")); //180
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "09:00", "10:00")); //210
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "10:00")); //420


            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "09:00", "12:00")); //0
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "09:00", "12:00")); //0
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "09:00", "12:00")); //30
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "09:00", "12:00")); //120
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "09:00", "12:00")); //180
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "09:00", "12:00")); //180
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "09:00", "12:00")); //210
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "12:00")); //420




            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "08:00", "12:00")); //1









            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "08:00", "12:00")); //240
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "12:00")); //240
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "10:00")); //420
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:30", "09:00", "10:00")); //180
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "09:00", "10:00")); //180
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "16:30", "09:00", "10:00")); //390


            //#endregion
            //#region leave time ở ca 2
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "13:00", "14:00")); //60
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "13:00", "14:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "13:00", "14:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "13:00", "14:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "13:00", "14:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "13:00", "14:00")); //270
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "13:00", "14:00")); //420
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "13:00", "14:00")); //420


            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "14:00", "15:00")); //60
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "14:00", "15:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "14:00", "15:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "14:00", "15:00")); //270
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "14:00", "15:00")); //300
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "14:00", "15:00")); //420
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "14:00", "15:00")); //420


            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "14:00", "17:00")); //60
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "14:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "14:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "14:00", "17:00")); //270
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "14:00", "17:00")); //300
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "14:00", "17:00")); //300
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "14:00", "17:00")); //300



            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "13:00", "17:00")); //60
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "13:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "13:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "13:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "13:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "13:00", "17:00")); //240
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "13:00", "17:00")); //240


            //#endregion
            //#endregion
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "08:00", "09:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "08:30", "09:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "07:30", "08:30", "12:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "09:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "12:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "14:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "13:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "14:00", "14:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "09:00", "14:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "10:15", "08:00", "10:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:15", "08:00", "10:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:15", "09:00", "11:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:15", "09:00", "11:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:15", "10:00", "14:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:15", "10:00", "14:00"));
            ////Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:15", "10:00", "14:00"));

            ///////*
            //////In case I have a night shift (18:00 -> 06:00) -> if I sign in at 05:00 (this is quite ambiguous because I don't know if it was 05:00 yesterday or 05:00 tomorrow.
            //////So I chose to sign in yesterday. If I have additional information about the day, that is clear to check.   
            //////*/
            ////Console.WriteLine(Program.calculateLate("18:00", "06:00", "23:00", "02:00", "20:15", "19:00", "20:00"));


            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "20:15", "16:00", "17:00"));
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "20:15", "10:00", "11:00"));
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "20:15", "10:00", "13:00"));
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "20:15", "10:00", "14:00"));
            //Console.WriteLine(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "20:15", "10:00", "14:00"));






            Console.ReadLine();

        }
    }
   
  
}
