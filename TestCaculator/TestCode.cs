using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ByteHRTest;


namespace TestCaculator
{
    [TestFixture]
    public class TestCode
    {
        [Test]
        public static void SubTest()
        {

         

            #region không leave time
            #region sign in ở ca 1 
           Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:15"), Is.EqualTo(15));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:15"), Is.EqualTo(240));
            #endregion

            #region sign in ở ca 2
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:59"), Is.EqualTo( 239));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:40"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:15"), Is.EqualTo(255));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "15:30"), Is.EqualTo( 390));

            #region qua ngày
            //Assert.That(Program.calculateLate("19:00", "17:00", "20:00", "21:00", "20:30")Is.EqualTo(390));
            #endregion
            #endregion
            #endregion

            #region có leave time
            #region leave time ở ca 1
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "08:00", "09:00"), Is.EqualTo(1));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "08:00", "09:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "08:00", "09:00"), Is.EqualTo(120));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "08:00", "09:00"), Is.EqualTo(180));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "08:00", "09:00"), Is.EqualTo(180));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "09:00"), Is.EqualTo(210));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "08:00", "09:00"), Is.EqualTo(420));



            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "09:00", "10:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "09:00", "10:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "09:00", "10:00"), Is.EqualTo(30));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "09:00", "10:00"), Is.EqualTo(120));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "09:00", "10:00"), Is.EqualTo(180));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "09:00", "10:00"), Is.EqualTo(180));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "09:00", "10:00"), Is.EqualTo(210));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "10:00"), Is.EqualTo(420));


            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "09:00", "12:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "09:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "09:00", "12:00"), Is.EqualTo(30));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "09:00", "12:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "09:00", "12:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "09:00", "12:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "09:00", "12:00"), Is.EqualTo(90));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "09:00", "12:00"), Is.EqualTo(300));


            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:01", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "08:00", "12:00"), Is.EqualTo(0));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "08:00", "12:00"), Is.EqualTo(30));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "08:00", "12:00"), Is.EqualTo(240));


            #endregion

            #region leave time ở ca 2
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "13:00", "14:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "13:00", "14:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "13:00", "14:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "13:00", "14:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "13:00", "14:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "13:00", "14:00"), Is.EqualTo(270));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "13:00", "14:00"), Is.EqualTo(420));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "13:00", "14:00"), Is.EqualTo(420));

            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "14:00", "15:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "14:00", "15:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "14:00", "15:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "14:00", "15:00"), Is.EqualTo(270));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "14:00", "15:00"), Is.EqualTo(300));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "14:00", "15:00"), Is.EqualTo(420));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:30", "14:00", "15:00"), Is.EqualTo(420));


            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "14:00", "17:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "14:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "14:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "14:00", "17:00"), Is.EqualTo(270));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "14:00", "17:00"), Is.EqualTo(300));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "14:00", "17:00"), Is.EqualTo(300));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "14:00", "17:00"), Is.EqualTo(300));



            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "09:00", "13:00", "17:00"), Is.EqualTo(60));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "13:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "13:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:30", "13:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "13:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:30", "13:00", "17:00"), Is.EqualTo(240));
            Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "13:00", "17:00"), Is.EqualTo(240));


            #endregion

            #region leave time ở ca break
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "11:00", "12:30"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "11:00", "12:30"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "11:00", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "11:00", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "11:00", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "11:00", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "11:00", "12:30"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "11:00", "12:30"), Is.EqualTo(420));

                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "11:00", "13:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "11:00", "13:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "11:00", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "11:00", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "11:00", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "11:00", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "11:00", "13:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "11:00", "13:00"), Is.EqualTo(420));



                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "11:00", "14:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "11:00", "14:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "11:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "11:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "11:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "11:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "11:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "11:00", "14:00"), Is.EqualTo(360));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "11:00", "17:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "11:00", "17:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "11:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "11:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "11:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "11:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "11:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "11:00", "17:00"), Is.EqualTo(180));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:00", "12:30"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:00", "12:30"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:00", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:00", "12:30"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:00", "12:30"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:00", "12:30"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:00", "12:30"), Is.EqualTo(300));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:00", "12:30"), Is.EqualTo(480));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:00", "13:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:00", "13:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:00", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:00", "13:00"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:00", "13:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:00", "13:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:00", "13:00"), Is.EqualTo(300));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:00", "13:00"), Is.EqualTo(480));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:00", "14:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:00", "14:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:00", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:00", "14:00"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:00", "14:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:00", "14:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:00", "14:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:00", "14:00"), Is.EqualTo(420));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:00", "17:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:00", "17:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:00", "17:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:00", "17:00"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:00", "17:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:00", "17:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:00", "17:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:00", "17:00"), Is.EqualTo(240));



                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:30", "12:30"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:30", "12:30"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:30", "12:30"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:30", "12:30"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:30", "12:30"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:30", "12:30"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:30", "12:30"), Is.EqualTo(300));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:30", "12:30"), Is.EqualTo(480));



                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:30", "13:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:30", "13:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:30", "13:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:30", "13:00"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:30", "13:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "13:00", "12:30", "13:00"), Is.EqualTo(240));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "14:00", "12:30", "13:00"), Is.EqualTo(300));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "17:00", "12:30", "13:00"), Is.EqualTo(480));


                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:00", "12:30", "14:00"), Is.EqualTo(0));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "08:30", "12:30", "14:00"), Is.EqualTo(30));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:00", "12:30", "14:00"), Is.EqualTo(180));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "11:30", "12:30", "14:00"), Is.EqualTo(210));
                Assert.That(Program.calculateLate("08:00", "17:00", "12:00", "13:00", "12:00", "12:30", "14:00"), Is.EqualTo(240));

            #endregion
            #endregion
        }
        public static void Main()
        {
            SubTest();
        }
    }
}
