using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libplctag;
using libplctag.DataTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Timers;
using System.Security.Claims;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AB_DataAdquisition_Test01
{
    public partial class Main : Form
    {
        public Main()
        {

            InitializeComponent();
            timer1.Start();
            //Inicializar Datos
            txt01_DINT_Read.Text = "";
            txt02.Text = "";
            txt_array01.Text = "";

            /*
            var dintTag2 = new Tag<DintPlcMapper, int>()
            {
                Name = "vol_AGVs_IN_USE",
                //Gateway is the IP Address of the PLC or communication module.
                Gateway = "192.168.248.10",
                //Path is the location in the control plane of the CPU. Almost always "1,0".
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip
            };
            dintTag2.Read();
            txt01_DINT_Read.Text = dintTag2.Value.ToString();
            */


        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            Scan.Enabled = true;





        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            //Stop Scan
            Scan.Enabled = false;

            //Inicializar Datos
            txt01_DINT_Read.Text = "";
            txt02.Text = "";
            txt_Real_02.Text = "";
            txt_Real_03.Text = "";
            txt_array01.Text = "";
            txt_array02.Text = "";
            txt_array03.Text = "";
            txt_array04.Text = "";
            txt_array05.Text = "";
            txt_array06.Text = "";
            txt_array07.Text = "";
            txt_array08.Text = "";
            txt_array09.Text = "";
        }

        private void Scan_Tick(object sender, EventArgs e)
        {
            var dintTag = new Tag<DintPlcMapper, int>()
            {
                Name = "vol_AGVs_IN_USE",
                //Gateway is the IP Address of the PLC or communication module.
                Gateway = "192.168.248.10",
                //Path is the location in the control plane of the CPU. Almost always "1,0".
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip


            };


            dintTag.Read();
            txt01_DINT_Read.Text = dintTag.Value.ToString();

            var realTag = new Tag<RealPlcMapper, float>()
            {
                Name = "Production_Sync_Speed",
                //Gateway is the IP Address of the PLC or communication module.
                Gateway = "192.168.248.10",
                //Path is the location in the control plane of the CPU. Almost always "1,0".
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip
            };
            realTag.Read();
            txt02.Text = realTag.Value.ToString();

            var realTag02 = new Tag<RealPlcMapper, float>()
            {
                Name = "System.AGV[43].STATUS.R4",
                //Gateway is the IP Address of the PLC or communication module.
                Gateway = "192.168.248.10",
                //Path is the location in the control plane of the CPU. Almost always "1,0".
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip
            };
            realTag02.Read();
            txt_Real_02.Text = realTag02.Value.ToString();

            var realTag03 = new Tag<RealPlcMapper, float>()
            {
                Name = "System.AGV[25].STATUS.R4",
                //Gateway is the IP Address of the PLC or communication module.
                Gateway = "192.168.248.10",
                //Path is the location in the control plane of the CPU. Almost always "1,0".
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip
            };
            realTag03.Read();
            txt_Real_03.Text = realTag03.Value.ToString();


            var dintArrayTag = new Tag<DintPlcMapper, int[]>()
            {
                Name = "ProgramRevisionArray",
                Gateway = "192.168.248.10",
                Path = "1,0",
                PlcType = PlcType.ControlLogix,
                Protocol = Protocol.ab_eip,
                ArrayDimensions = new int[] { 100 },
                Timeout = TimeSpan.FromMilliseconds(5000),
            };
            dintArrayTag.Read();

            txt_array01.Text = dintArrayTag.Value[1].ToString();
            txt_array02.Text = dintArrayTag.Value[2].ToString();
            txt_array03.Text = dintArrayTag.Value[3].ToString();
            txt_array04.Text = dintArrayTag.Value[4].ToString();
            txt_array05.Text = dintArrayTag.Value[5].ToString();
            txt_array06.Text = dintArrayTag.Value[14].ToString();
            txt_array07.Text = dintArrayTag.Value[33].ToString();
            txt_array08.Text = dintArrayTag.Value[43].ToString();
            txt_array09.Text = dintArrayTag.Value[50].ToString();

        }
        int percentageTank1 = 93;//This Variable will be replaced with the value of the Tank 1
        int percentageTank2 = 69;//This Variable will be replaced with the value of the Tank 2
        int percentageTank3 = 69;//This Variable will be replaced with the value of the Tank 3
        int percentageTank4 = 31;//This Variable will be replaced with the value of the Tank 4
        int percentageTank5 = 15;//This Variable will be replaced with the value of the Tank 5
        int percentageTank6 = 10;//This Variable will be replaced with the value of the Tank 6
        int percentageTank7 = 45;//This Variable will be replaced with the value of the Tank 7
        int percentageTank8 = 92;//This Variable will be replaced with the value of the Tank 8
        int percentageTank9 = 95;//This Variable will be replaced with the value of the Tank 9

        int fanTank1 = 51;//This Variable will be replaced with the value of the temperature of tank 1 
        int fanTank2 = 52;//This Variable will be replaced with the value of the temperature of tank 2 
        int fanTank3 = 53;//This Variable will be replaced with the value of the temperature of tank 3 
        int fanTank4 = 54;//This Variable will be replaced with the value of the temperature of tank 4 
        int fanTank5 = 55;//This Variable will be replaced with the value of the temperature of tank 5 
        int fanTank6 = 56;//This Variable will be replaced with the value of the temperature of tank 6 
        int fanTank7 = 57;//This Variable will be replaced with the value of the temperature of tank 7 
        int fanTank8 = 58;//This Variable will be replaced with the value of the temperature of tank 8 
        int fanTank9 = 59;//This Variable will be replaced with the value of the temperature of tank 9 


        bool pumpContainer1 = false;//This Variable will be replaced with the value of the pump on and off indicator in container 1
        bool pumpContainer2 = true;//This Variable will be replaced with the value of the pump on and off indicator in container 2
        bool pumpContainer3 = false;//This Variable will be replaced with the value of the pump on and off indicator in container 3    
        bool pumpContainer4 = false;//This Variable will be replaced with the value of the pump on and off indicator in container 4
        bool pumpContainer5 = true;//This Variable will be replaced with the value of the pump on and off indicator in container 5

        string open = "open";
        string closed = "close";

        bool PreassureArrows11 = false;  //This variable will be replaced with the value of the preassure arrows on container 1
        bool PreassureArrows12 = true;  //This variable will be replaced with the value of the preassure arrows on container 1
        bool PreassureArrows21 = false;  //This variable will be replaced with the value of the preassure arrows on container 2
        bool PreassureArrows22 = true;  //This variable will be replaced with the value of the preassure arrows on container 2
        bool PreassureArrows23 = false;  //This variable will be replaced with the value of the preassure arrows on container 2
        bool PreassureArrows31 = true;  //This variable will be replaced with the value of the preassure arrows on container 3
        bool PreassureArrows32 = false;  //This variable will be replaced with the value of the preassure arrows on container 3
        bool PreassureArrows41 = true;  //This variable will be replaced with the value of the preassure arrows on container 4
        bool PreassureArrows42 = false;  //This variable will be replaced with the value of the preassure arrows on container 4
        bool PreassureArrows43 = true;  //This variable will be replaced with the value of the preassure arrows on container 4

        int fanInfoContainer1 = 10;//This Variable Will be replaced with the information of fan pump1
        int fanInfoContainer2 = 20;//This Variable Will be replaced with the information of fan pump2
        int fanInfoContainer3 = 30;//This Variable Will be replaced with the information of fan pump3
        int fanInfoContainer4 = 40;//This Variable Will be replaced with the information of fan pump4
        int fanInfoContainer5 = 40;//This Variable Will be replaced with the information of fan pump4


        int tankCapacity = 200;//This variable represent the capacity of any tank 
        bool Valve3 = true; //This Variable will be replaced with the inofrmation of the valve open or closed in container 3
        bool Valve4 = true; //This Variable will be replaced with the inofrmation of the valve open or closed in container 4
        private void button1_Click(object sender, EventArgs e)//Test Button 
        {
            percentageTank4 += 3;
             percentageTank3 += 2;
            percentageTank6 += 1;
            percentageTank9 += 1;
           
        }
        public void button2_Click(object sender, EventArgs e)//Test Button
        {
            percentageTank4 -= 3;
            percentageTank3 -= 2;
            percentageTank6 -= 1;
            percentageTank9 -= 1;

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            PreassureArrows21 = true;
            PreassureArrows31 = false;
            PreassureArrows41 = true;
            pumpContainer1 = true;
            pumpContainer2 = true;
            pumpContainer3 = true;
            pumpContainer4 = true;
            pumpContainer5 = true;
            Valve3 = true;
            Valve4 = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PreassureArrows21 = false;
            PreassureArrows31 = true;
            PreassureArrows41 = false;
            pumpContainer1 = false;
            pumpContainer2 = false;
            pumpContainer3 = false;
            pumpContainer4 = false;
            pumpContainer5 = false;
            Valve3 = false;
            Valve4 = false;
        }
        /*
         * THIS TIMER TICK PROVIDES THE UPDATE EVERY 2 SECONDS OF THE SYSTEM, SUCH AS THE VALUE OF THE TANKS DISPLAYED AND ALSO 
         * THE ALARMS THAT AR GOING ON, ALSO IT ALLOWS TO CHANGE THE GRAPHS DISPLAYED AND ALSO THE LOG DISPLAYED
         * */
        private void timer1_Tick(object sender, EventArgs e)//Every Time 1second is elapsed the information will be displayed
        {
            Tank1();
            Tank2();
            Tank3();
            Tank4();
            Tank5();
            Tank6();
            Tank7();
            Tank8();
            Tank9();
            
         
            containerAlarms();
            pump();
            preassureArrows();
            FanTanks();
            alarmTrigger1(percentageTank9, percentageTank4, 9, 4, alarmImage1, alarm1);
            alarmTrigger1(percentageTank5, percentageTank3, 5, 3, alarmImage2, alarm2);
            alarmTrigger1(percentageTank1, percentageTank2, 1, 2, alarmImage3, alarm3);
            alarmTrigger2(percentageTank6, percentageTank7, percentageTank8, 6, 7, 8, alarmImage4, alarm4);
            caseGraph(selector);
            warnings(warning1, WarningImage1, Warning1, warning1msg);
            warnings(warning2, WarningImage2, Warning2, warning2msg);
            warnings(warning3, WarningImage3, Warning3, warning3msg);
            warnings(warning4, WarningImage4, Warning4, warning4msg);
            logQuery();
        }

        //Data Tanks 
        private void Tank1()//Tank 1 Information and data 
        {
            progressTank11.Value = percentageTank1;
            TxtTank11.Text = (percentageTank1.ToString() + "%");
            progressTank12.Value = progressTank11.Value;
            TxtTank12.Text = (percentageTank1.ToString() + "%");

            //Tank Litters
            progressTank13.Value = progressTank11.Value;
            TxtTank13.Text = ((percentageTank1 * (tankCapacity / 100)) + "L");


            //Alarm Indicator 
            labelColors(percentageTank1, TxtTank11);
            tankAlarms(percentageTank1, alarmTank1);

        }
        private void Tank2()//Tank 2 Information and data
        {
            progressTank21.Value = percentageTank2;
            TxtTank21.Text = (percentageTank2.ToString() + "%");
            progressTank22.Value = progressTank21.Value;
            TxtTank22.Text = (percentageTank2.ToString() + "%");

            //Tank Litters
            progressTank23.Value = progressTank21.Value;
            TxtTank23.Text = ((percentageTank2 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank2, TxtTank21);
            tankAlarms(percentageTank2, alarmTank2);
        }
        private void Tank3()//Tank 3 Information and data
        {
            progressTank31.Value = percentageTank3;
            TxtTank31.Text = (percentageTank3.ToString() + "%");
            progressTank32.Value = progressTank31.Value;
            TxtTank32.Text = (percentageTank3.ToString() + "%");


            //Tank Litters
            progressTank33.Value = progressTank31.Value;
            TxtTank33.Text = ((percentageTank3 * (tankCapacity / 100)) + "L");


            //Alarm Indicator 
            labelColors(percentageTank3, TxtTank31);
            tankAlarms(percentageTank3, alarmTank3);
        }
        private void Tank4()//Tank 4 Information and data
        {
            progressTank41.Value = percentageTank4;
            TxtTank41.Text = (percentageTank4.ToString() + "%");
            progressTank42.Value = progressTank41.Value;
            TxtTank42.Text = (percentageTank4.ToString() + "%");


            //Tank Litters
            progressTank43.Value = progressTank41.Value;
            TxtTank43.Text = ((percentageTank4 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank4, TxtTank41);
            tankAlarms(percentageTank4, alarmTank4);
        }
        private void Tank5()//Tank 5 Information and data
        {
            progressTank51.Value = percentageTank5;
            TxtTank51.Text = (percentageTank5.ToString() + "%");
            progressTank52.Value = progressTank51.Value;
            TxtTank52.Text = (percentageTank5.ToString() + "%");

            //Tank Litters
            progressTank53.Value = progressTank51.Value;
            TxtTank53.Text = ((percentageTank5 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 

            labelColors(percentageTank5, TxtTank51);
            tankAlarms(percentageTank5, alarmTank5);
        }
        private void Tank6()//Tank 6 Information and data
        {
            progressTank61.Value = percentageTank6;
            TxtTank61.Text = (percentageTank6.ToString() + "%");
            progressTank62.Value = progressTank61.Value;
            TxtTank62.Text = (percentageTank6.ToString() + "%");
            //Tank Litters
            progressTank63.Value = progressTank61.Value;
            TxtTank63.Text = ((percentageTank6 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank6, TxtTank61);
            tankAlarms(percentageTank6, alarmTank6);
        }
        private void Tank7()//Tank 7 Information and data
        {
            progressTank71.Value = percentageTank7;
            TxtTank71.Text = (percentageTank7.ToString() + "%");
            progressTank72.Value = progressTank71.Value;
            TxtTank72.Text = (percentageTank7.ToString() + "%");

            //Tank Litters
            progressTank73.Value = progressTank71.Value;
            TxtTank73.Text = ((percentageTank7 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank7, TxtTank71);
            tankAlarms(percentageTank7, alarmTank7);
        }
        private void Tank8()//Tank 8 Information and data
        {
            progressTank81.Value = percentageTank8;
            TxtTank81.Text = (percentageTank8.ToString() + "%");
            progressTank82.Value = progressTank81.Value;
            TxtTank82.Text = (percentageTank8.ToString() + "%");

            //Tank Litters
            progressTank83.Value = progressTank81.Value;
            TxtTank83.Text = ((percentageTank8 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank8, TxtTank81);
            tankAlarms(percentageTank8, alarmTank8);

        }
        private void Tank9()//Tank 9 Information and data
        {
            progressTank91.Value = percentageTank9;
            TxtTank91.Text = (percentageTank9.ToString() + "%");
            progressTank92.Value = progressTank91.Value;
            TxtTank92.Text = (percentageTank9.ToString() + "%");

            //Tank Litters
            progressTank93.Value = progressTank91.Value;
            TxtTank93.Text = ((percentageTank9 * (tankCapacity / 100)) + "L");

            //Alarm Indicator 
            labelColors(percentageTank9, TxtTank91);
            tankAlarms(percentageTank9, alarmTank9);
        }

        private void containerAlarms()
        {
            //Alarm Container 9&4
            if ((percentageTank4 >= 95 || percentageTank9 >= 95) || (percentageTank4 <= 10 || percentageTank9 <= 10))
            {
                ContainerAlarm1.Visible = true;
            }
            if ((percentageTank4 < 95 && percentageTank9 < 95) && (percentageTank4 > 10 && percentageTank9 > 10))
            {
                ContainerAlarm1.Visible = false;
            }

            //Alarm Container 3&5
            if ((percentageTank3 >= 95 || percentageTank5 >= 95) || (percentageTank3 <= 10 || percentageTank5 <= 10))
            {
                ContainerAlarm2.Visible = true;
            }
            if ((percentageTank3 < 95 && percentageTank5 < 95) && (percentageTank3 > 10 && percentageTank5 > 10))
            {
                ContainerAlarm2.Visible = false;
            }
            //Alarm Container 1&2
            if ((percentageTank1 >= 95 || percentageTank2 >= 95) || (percentageTank1 <= 10 || percentageTank2 <= 10))
            {
                ContainerAlarm3.Visible = true;
            }
            if ((percentageTank1 < 95 && percentageTank2 < 95) && (percentageTank1 > 10 && percentageTank2 > 10))
            {
                ContainerAlarm3.Visible = false;
            }
            //Alarm Container 6,7 & 8
            if ((percentageTank6 >= 95 || percentageTank7 >= 95 || percentageTank8 >= 95) || (percentageTank6 <= 10 || percentageTank7 <= 10 || percentageTank8 <= 10))
            {
                ContainerAlarm4.Visible = true;
            }
            if ((percentageTank6 < 95 && percentageTank7 < 95 && percentageTank8 < 95) && (percentageTank6 > 10 && percentageTank7 > 10 && percentageTank8 > 10))
            {
                ContainerAlarm4.Visible = false;
            }
        }
        private void pump()//Represents the Pump animation, Pump on or OFF depnends on a Bool
        {
            //PumpContainer1
            pumps(pumpContainer1, pumpOnContainer1, pumpOFFContainer1);
            //PumpContainer2
            pumps(pumpContainer2, pumpOnContainer2, pumpOFFContainer2);
            //PumpContainer 3
            pumps(pumpContainer3, pumpOnContainer3, pumpOffContainer3);
            //PumpContainer 4.1
            pumps(pumpContainer4, pumpOnContainer4, pumpOFFContainer4);
            //PumpContainer 4.2
            pumps(pumpContainer5, pumpOnContainer5, pumpOFFContainer5);

            //Fan Infomation Pump1
            FanInfo1.Value = fanInfoContainer1;
            FanLabel1.Text = (fanInfoContainer1.ToString() + "F");

            FanInfo2.Value = fanInfoContainer2;
            FanLabel2.Text = (fanInfoContainer2.ToString() + "F");

            FanInfo3.Value = fanInfoContainer3;
            FanLabel3.Text = (fanInfoContainer3.ToString() + "F");

            FanInfo4.Value = fanInfoContainer4;
            FanLabel4.Text = (fanInfoContainer4.ToString() + "F");


            FanInfo5.Value = fanInfoContainer5;
            FanLabel5.Text = (fanInfoContainer5.ToString() + "F");

            //VALVES OPEN OR CLOSED

            valvesPos(Valve3, ValveOpen3, ValveClosed3);
            valvesPos(Valve4, ValveOpen4, ValveClosed4);




        }
        private void preassureArrows()//Similar to the pump animation, this will be replace for the preassure variable
        {
            //First set of Arrows container 1
            arrows(PreassureArrows11, TomatoArrowsC11, GrayArrowsC11);
            //Second set of Arrows container 1
            arrows(PreassureArrows12, TomatoArrowsC12, GrayArrowsC12);
            //First set of Arrows container 2
            arrows(PreassureArrows21, TomatoArrowsC21, GrayArrowsC21);
            //Second set of Arrows container 2
            arrows(PreassureArrows22, TomatoArrowsC22, GrayArrowsC22);
            //Third set of Arrows container 2
            arrows(PreassureArrows23, TomatoArrowsC23, GrayArrowsC23);
            //First set of Arrows container 3
            arrows(PreassureArrows31, TomatoArrowsC31, GrayArrowsC31);
            //Second set of Arrows container 3
            arrows(PreassureArrows32, TomatoArrowsC32, GrayArrowsC32);
            //First ser of Arrows Container 4
            arrows(PreassureArrows41, TomatoArrowsC41, GrayArrowsC41);
            //Second set of Arrows Container 4
            arrows(PreassureArrows42, TomatoArrowsC42, GrayArrowsC42);
            //Third set of Arrows Container 4
            arrows(PreassureArrows43, TomatoArrowsC43, GrayArrowsC43);
        }
        private void FanTanks()
        {
            //Fan Tank1
            FanTanksInformation(progressbarTemp1, fanTank1, TxtTemp1);
            //Fan Tank2
            FanTanksInformation(progressbarTemp2, fanTank2, TxtTemp2);
            //Fan Tank3
            FanTanksInformation(progressbarTemp3, fanTank3, TxtTemp3);
            //Fan Tank4
            FanTanksInformation(progressbarTemp4, fanTank4, TxtTemp4);
            //Fan Tank5
            FanTanksInformation(progressbarTemp5, fanTank5, TxtTemp5);
            //Fan Tank6
            FanTanksInformation(progressbarTemp6, fanTank6, TxtTemp6);
            //Fan Tank7
            FanTanksInformation(progressbarTemp7, fanTank7, TxtTemp7);
            //Fan Tank8
            FanTanksInformation(progressbarTemp8, fanTank8, TxtTemp8);
            //Fan Tank9
            FanTanksInformation(progressbarTemp9, fanTank9, TxtTemp9);
        }
        private void labelColors(int labelValue, Label labelTxt)//It receives the value of the tank and the label tha will be change in order to change 
                                                                //the color
        {
            if (labelValue <= 10)
            {
                labelTxt.BackColor = Color.Red;
            }
            if (labelValue > 10 && labelValue <= 70)
            {
                labelTxt.BackColor = Color.Yellow;
            }
            if (labelValue > 70)
            {
                labelTxt.BackColor = Color.Chartreuse;
            }
        }

        private async void tankAlarms(int percentageTank, PictureBox alarmTank)//Function to represent the alarm Tanks
        {
            if (percentageTank >= 95 || percentageTank <= 10)
            {

                //alarmTank.Visible = true;

                alarmTank.Visible = true;
                await Task.Delay(1200);
                alarmTank.Visible = false;

            }
            if (percentageTank <= 94 && percentageTank > 10)
            {
                alarmTank.Visible = false;
            }
        }

        private void valvesPos(bool valve, PictureBox Open, PictureBox Closed)//Function of valves positions that will be 
        {
            if (valve == true) //The PumpON variable will be replace in order to be related to the fan
            {
                Open.Visible = true;
                Closed.Hide();
                Closed.Visible = false;
            }
            if (valve == false)
            {
                Closed.Visible = true;
                Open.Hide();
                Open.Visible = false;
            }
        }
        private void pumps(bool pumpContainer, PictureBox open, PictureBox closed)//Function to the animation of the pumps
        {
            if (pumpContainer == true) //The PumpON variable will be replace in order to be related to the fan
            {
                open.Visible = true;
                closed.Hide();
                closed.Visible = false;
            }
            if (pumpContainer == false)
            {
                closed.Visible = true;
                open.Hide();
                open.Visible = false;
            }
        }
        private void arrows(bool preassureArrows, PictureBox on, PictureBox off)//This function provides the preassure arrows
        {
            if (preassureArrows == true)
            {
                on.Visible = true;
                off.Hide();
                off.Visible = false;
            }
            if (preassureArrows == false)
            {
                off.Visible = true;
                on.Hide();

            }

        }
        private void FanTanksInformation(System.Windows.Forms.ProgressBar tankvalueTemp, int tank, Label tankLabel)
        {
            tankvalueTemp.Value = tank;
            tankLabel.Text = (tankvalueTemp.Value.ToString() + "°F");
        }

        /*
         * THE MAIN LOAD WILL DISPLAY EVERY TIME THE SYSTEM STARTS, THIS PROVIDE THE SYSTEM TO GRAB THE INITIAL CONDITIONS IN WHICH 
         * THE SYSTEM IS AT 
         */
        public void Main_Load(object sender, EventArgs e)
        {

        
            dateTimes = dateTimes.Append(DateTime.Now.ToString()).ToArray();
            valveStatusContainer1 = valveStatusContainer1.Append(pumpContainer1).ToArray();
            fanSatusConatiner1 = fanSatusConatiner1.Append(fanInfoContainer1).ToArray();
            valveStatusContainer2 = valveStatusContainer2.Append(pumpContainer2).ToArray();
            fanSatusConatiner2 = fanSatusConatiner2.Append(fanInfoContainer2).ToArray();
            valveStatusContainer3 = valveStatusContainer3.Append(pumpContainer3).ToArray();
            fanSatusConatiner3 = fanSatusConatiner3.Append(fanInfoContainer3).ToArray();
            valveStatusContainer4 = valveStatusContainer4.Append(pumpContainer4).ToArray();
            fanSatusConatiner4 = fanSatusConatiner4.Append(fanInfoContainer4).ToArray();
            valveStatusContainer5 = valveStatusContainer5.Append(pumpContainer5).ToArray();
            fanSatusConatiner5 = fanSatusConatiner5.Append(fanInfoContainer5).ToArray();
            valvePosition3 = valvePosition3.Append(Valve3).ToArray();
            valvePosition4 = valvePosition4.Append(Valve4).ToArray();
            graphCapacity1 = graphCapacity1.Append(percentageTank1).ToArray();
            graphCapacity2 = graphCapacity2.Append(percentageTank2).ToArray();
            graphCapacity3 = graphCapacity3.Append(percentageTank3).ToArray();
            graphCapacity4 = graphCapacity4.Append(percentageTank4).ToArray();
            graphCapacity5 = graphCapacity5.Append(percentageTank5).ToArray();
            graphCapacity6 = graphCapacity6.Append(percentageTank6).ToArray();
            graphCapacity7 = graphCapacity7.Append(percentageTank7).ToArray();
            graphCapacity8 = graphCapacity8.Append(percentageTank8).ToArray();
            graphCapacity9 = graphCapacity9.Append(percentageTank9).ToArray();

            temperatureTank1 = temperatureTank1.Append(fanTank1).ToArray();
            temperatureTank2 = temperatureTank2.Append(fanTank2).ToArray();
            temperatureTank3 = temperatureTank3.Append(fanTank3).ToArray();
            temperatureTank4 = temperatureTank4.Append(fanTank4).ToArray();
            temperatureTank5 = temperatureTank5.Append(fanTank5).ToArray();
            temperatureTank6 = temperatureTank6.Append(fanTank6).ToArray();
            temperatureTank7 = temperatureTank7.Append(fanTank7).ToArray();
            temperatureTank8 = temperatureTank8.Append(fanTank8).ToArray();
            temperatureTank9 = temperatureTank9.Append(fanTank9).ToArray();
            DateTime moment = DateTime.Now;
            int hour1 = moment.Hour;
            // hour.Append(moment.Minute);
            hour = hour.Append(hour1).ToArray();

            caseGraph(selector);
           

        }

        private string txtPumps(bool pump)
        {
            if (pump)
            {
                return open;
            }
            else
            {
                return closed;
            }
        }
        int[] graphCapacity1 = { };
        int[] graphCapacity2 = { };
        int[] graphCapacity3 = { };
        int[] graphCapacity4 = { };
        int[] graphCapacity5 = { };
        int[] graphCapacity6 = { };
        int[] graphCapacity7 = { };
        int[] graphCapacity8 = { };
        int[] graphCapacity9 = { };
        int[] temperatureTank1 = { };
        int[] temperatureTank2 = { };
        int[] temperatureTank3 = { };
        int[] temperatureTank4 = { };
        int[] temperatureTank5 = { };
        int[] temperatureTank6 = { };
        int[] temperatureTank7 = { };
        int[] temperatureTank8 = { };
        int[] temperatureTank9 = { };

        string[] dateTimes = { };
        int logSelector = 1;
        int[] hour = { };
        int selector = 9;
        bool[] valveStatusContainer1 = { };
        bool[] valvePosition3 = { };
        bool[] valvePosition4 = { };
        int[] fanSatusConatiner1 = { };
        bool[] valveStatusContainer2 = { };
        int[] fanSatusConatiner2 = { };
        bool[] valveStatusContainer3 = { };
        int[] fanSatusConatiner3 = { };
        bool[] valveStatusContainer4 = { };
        int[] fanSatusConatiner4 = { };
        bool[] valveStatusContainer5 = { };
        int[] fanSatusConatiner5 = { };
        bool warning1 = true;
        string warning1msg = "[WARNING] Valve A1 has been open for hours, consider checking for leaks";
        bool warning2 = true;
        bool warning3 = false;
        bool warning4 = false;
        string warning2msg = "[WARNING] Tank 2 level dropping faster than usual, monitor closely";
        string warning3msg = "[WARNING] Temperature Sensor T1 fluctuating";
        string warning4msg = "[WARNING] Tank 3 level dropping faster than usual, monitor closely";

        /*
         *  THE TIMER TICK IS THE MOST IMPORTANT ELEMENT, EVERY TIME IT TRIGGERS IT WILL
         *  SAVE ALL THE INFORMATION THAT IS SHOWN IN THE GRAPHS AND IN THE LOG
         */

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            checkList1(graphCapacity1);
            checkList2(graphCapacity2);
            checkList3(graphCapacity3);
            checkList4(graphCapacity4);
            checkList5(graphCapacity5);
            checkList6(graphCapacity6);
            checkList7(graphCapacity7);
            checkList8(graphCapacity8);
            checkList9(graphCapacity9);
            checkList11(temperatureTank1);
            checkList21(temperatureTank2);
            checkList31(temperatureTank3);
            checkList41(temperatureTank4);
            checkList51(temperatureTank5);
            checkList61(temperatureTank6);
            checkList71(temperatureTank7);
            checkList81(temperatureTank8);
            checkList91(temperatureTank9);
            checkListValveContainer1(valveStatusContainer1);
            checkFanStatusContainer1(fanSatusConatiner1);
            checkDateTimes(dateTimes);

            DateTime moment = DateTime.Now;
            int hour1 = moment.Hour;
            
            checkHour(hour);
            hour = hour.Append(hour1).ToArray();
            dateTimes = dateTimes.Append(DateTime.Now.ToString()).ToArray();
            valveStatusContainer1 = valveStatusContainer1.Append(pumpContainer1).ToArray();
            fanSatusConatiner1 = fanSatusConatiner1.Append(fanInfoContainer1).ToArray();
            valveStatusContainer2 = valveStatusContainer2.Append(pumpContainer2).ToArray();
            fanSatusConatiner2 = fanSatusConatiner2.Append(fanInfoContainer2).ToArray();
            valveStatusContainer3 = valveStatusContainer3.Append(pumpContainer3).ToArray();
            fanSatusConatiner3 = fanSatusConatiner3.Append(fanInfoContainer3).ToArray();
            valveStatusContainer4 = valveStatusContainer4.Append(pumpContainer4).ToArray();
            fanSatusConatiner4 = fanSatusConatiner4.Append(fanInfoContainer4).ToArray();
            valveStatusContainer5 = valveStatusContainer5.Append(pumpContainer5).ToArray();
            fanSatusConatiner5 = fanSatusConatiner5.Append(fanInfoContainer5).ToArray();
            valvePosition3 = valvePosition3.Append(Valve3).ToArray();
            valvePosition4 = valvePosition4.Append(Valve4).ToArray();

            graphCapacity1 = graphCapacity1.Append(percentageTank1).ToArray();
            graphCapacity2 = graphCapacity2.Append(percentageTank2).ToArray();
            graphCapacity3 = graphCapacity3.Append(percentageTank3).ToArray();
            graphCapacity4 = graphCapacity4.Append(percentageTank4).ToArray();
            graphCapacity5 = graphCapacity5.Append(percentageTank5).ToArray();
            graphCapacity6 = graphCapacity6.Append(percentageTank6).ToArray();
            graphCapacity7 = graphCapacity7.Append(percentageTank7).ToArray();
            graphCapacity8 = graphCapacity8.Append(percentageTank8).ToArray();
            graphCapacity9 = graphCapacity9.Append(percentageTank9).ToArray();

            temperatureTank1 = temperatureTank1.Append(fanTank1).ToArray();
            temperatureTank2 = temperatureTank2.Append(fanTank2).ToArray();
            temperatureTank3 = temperatureTank3.Append(fanTank3).ToArray();
            temperatureTank4 = temperatureTank4.Append(fanTank4).ToArray();
            temperatureTank5 = temperatureTank5.Append(fanTank5).ToArray();
            temperatureTank6 = temperatureTank6.Append(fanTank6).ToArray();
            temperatureTank7 = temperatureTank7.Append(fanTank7).ToArray();
            temperatureTank8 = temperatureTank8.Append(fanTank8).ToArray();
            temperatureTank9 = temperatureTank9.Append(fanTank9).ToArray();

            caseGraph(selector);
        }
        /*
         * EVERY BUTTON OF THE TANKS ARE A MENU THAT WILL BE CHOSEN IN ORDER TO CREATE THE GRAPH
         * */
        private void buttonTank1_Click(object sender, EventArgs e)
        {
            selector = 1;
        }

        private void buttonTank2_Click(object sender, EventArgs e)
        {
            selector = 2;

        }
        private void buttonTank3_Click(object sender, EventArgs e)
        {
            selector = 3;
        }
        private void buttonTank4_Click(object sender, EventArgs e)
        {
            selector = 4;
        }
        private void buttonTank5_Click(object sender, EventArgs e)
        {
            selector = 5;
        }
        private void buttonTank6_Click(object sender, EventArgs e)
        {
            selector = 6;
        }
        private void buttonTank7_Click(object sender, EventArgs e)
        {
            selector = 7;
        }
        private void buttonTank8_Click(object sender, EventArgs e)
        {
            selector = 8;
        }
        private void buttonTank9_Click(object sender, EventArgs e)
        {
            selector = 9;
        }
        private void graphCreator(int[] graph, int number, int[] graph2)//This is the creator of graphs, in stablish the x,y ax
                                                                        //is as well as the type and the label text an tiltles

        {
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = (hour.Min()) - 1;
            chart1.ChartAreas[0].AxisX.Maximum = (hour.Max()) + 1;
            chart1.Series[0].YAxisType = AxisType.Primary;
            chart1.Series.Clear();
            chart1.Titles.Clear();

            Title title = new Title();
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Text = "Tank: " + number;
            chart1.Titles.Add(title);


          
           
          
            Series serie = chart1.Series.Add("CAPACITY");
          
            Series serie1 = chart1.Series.Add("TEMPERATURE");
     
            int countGra = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                if (hour[i] >= 21)//Minutes or hours
                {
                    countGra = 1;
                    break;
                }

            }

            for (int i = 0; i < hour.Length; i++)
            {
                if ((hour[i] <= 4 && countGra == 1) || graph.Length == 1)
                {
                    countGra = 2;
                    serie.ChartType = SeriesChartType.Bubble;

                    serie1.ChartType = SeriesChartType.Bubble;
                    serie.BorderWidth = 3;
                    serie1.BorderWidth = 3;
                    chart1.ChartAreas[0].AxisX.Minimum = (hour.Min()) - 1;
                    chart1.ChartAreas[0].AxisX.Maximum = (hour.Max()) + 1;
                    chart1.ChartAreas[0].AxisX.Interval = 1;

                    break;
                }

            }
            if (countGra != 2)
            {
                serie.ChartType = SeriesChartType.Line;

                serie1.ChartType = SeriesChartType.Line;
                serie.BorderWidth = 10;
                serie1.BorderWidth = 10;
            }
            /*
             * IF THERE IS ONLY ONE VALUE, OR THE CHART IS ABOUT TO CHANGE FROM 12 TO 0, THE GRAPH WILL CHANGE TO FIGURES IN ORDER TO AVOID
             * LOSING THE VISUALIZATION
             * */
            for (int i = 0; i < graph.Length; i++) 
            {
                serie.Points.AddXY(hour[i], graph[i]);
                //serie.Points[0].Font = new System.Drawing.Font("Consolas", 10f);
            }

            for (int i = 0; i < graph2.Length; i++)
            {
                serie1.Points.AddXY(hour[i], graph2[i]);

            }
            chart1.Series[1].YAxisType = AxisType.Secondary;

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{R}%";
            chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "{R}°F";
            
            countGra = 0;
        }

        /*
         * 
         * This is a menu in which depending on the tank buttons that are press, the graph will be shown
         * */
        private void caseGraph(int graphSelector)
        {
            switch (graphSelector)
            {

                case 1:
                    graphCreator(graphCapacity1, 1, temperatureTank1);
                    break;
                case 2:
                    graphCreator(graphCapacity2, 2, temperatureTank1);
                    break;
                case 3:
                    graphCreator(graphCapacity3, 3, temperatureTank1);
                    break;
                case 4:
                    graphCreator(graphCapacity4, 4, temperatureTank1);
                    break;
                case 5:
                    graphCreator(graphCapacity5, 5, temperatureTank1);
                    break;
                case 6:
                    graphCreator(graphCapacity6, 6, temperatureTank1);
                    break;
                case 7:
                    graphCreator(graphCapacity7, 7, temperatureTank1);
                    break;
                case 8:
                    graphCreator(graphCapacity8, 8, temperatureTank1);
                    break;
                case 9:
                    graphCreator(graphCapacity9, 9, temperatureTank1);
                    break;

            }
        }
        /*
         THE CHECKLIST VERIFIES IF AN ARRAY EXCEEDS THE INFOMRATION THAT WANTS TO BE SHOW AND DELETES THE 
        FIRST VALUE SO THE LAST VALUE CAN BE STORED AND SHOWN
        
        FOR EXAMPLE IF THE ARRAY IS FULL, WHICH MEANS IT HAS THE 12 NUMBERS THAT REPRESENT THE HOURS, THE HOUR 13 WILL BE ADDED
        AND THE HOUR 1 WILL BE DELEATED, WHICH MEANS THE SECOND HOUR WILL ME MOVE TO THE FIRST ONE AND THE HOUR 13 TO THE TWUELVE
        SPOT AND THE FIRST ONE WILL BE ELIMINATED
         
         */
        private void checkList1(int[] check)
        {
            int[] clone = { };


            if (check.Length > 3)
            {

                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                graphCapacity1 = clone;
            }

        }
        private void checkList2(int[] check)
        {
            int[] clone = { };

            
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                graphCapacity2 = clone;
            }
        }
        private void checkList3(int[] check)
        {
            int[] clone = { };

          if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                graphCapacity3 = clone;
            }

        }
        private void checkList4(int[] check)
        {
            int[] clone = { };

           if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                graphCapacity4 = clone;

            }

        }
        private void checkList5(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                graphCapacity5 = clone;

            }

        }
        private void checkList6(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                graphCapacity6 = clone;
            }

        }
        private void checkList7(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                graphCapacity7 = clone;

            }

        }
        private void checkList8(int[] check)
        {
            int[] clone = { };

      
            if (check.Length > 3)

            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                graphCapacity8 = clone;

            }

        }
        private void checkList9(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                graphCapacity9 = clone;


            }

        }
        private void checkList11(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                temperatureTank1 = clone;

            }

        }
        private void checkList21(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                temperatureTank2 = clone;


            }

        }
        private void checkList31(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                temperatureTank3 = clone;
            }

        }
        private void checkList41(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                temperatureTank4 = clone;
            }

        }
        private void checkList51(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                temperatureTank5 = clone;



            }

        }
        private void checkList61(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                temperatureTank6 = clone;

            }

        }
        private void checkList71(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                temperatureTank7 = clone;

            }

        }
        private void checkList81(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    
                }
                temperatureTank8 = clone;

      
            }

        }
        private void checkList91(int[] check)
        {
            int[] clone = { };
            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                   
                }
                temperatureTank9 = clone;
            }

        } 
        private void checkHour(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();

                }
                hour = clone;



            }

        }
        private void checkListValveContainer1(bool[] check)
        {
            bool[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();

                }
                valveStatusContainer1 = clone;



            }
        }
        private void checkFanStatusContainer1(int[] check)
        {
            int[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();

                }
                fanSatusConatiner1 = clone;
            }
        }
        private void checkDateTimes(string[] check)
        {
            string[] clone = { };

            if (check.Length > 3)
            {
                for (int i = 1; i < 4; i++)
                {
                    clone = clone.Append(check[i]).ToArray();
                    txtStart = 0;
                }
                dateTimes = clone;
                
            }
        }
        //ALARMS 
        private void alarmTrigger1(int tank1, int tank2, int tanknum1, int tanknum2, PictureBox img, Label txt)
        
        {
            if ((tank1 >= 95 && tank2 >= 95) || (tank1 <= 10 && tank2 <= 10))
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum1 + " & TANK " + tanknum2 + " has reached " +
                    "critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if (tank1 >= 95 || tank1 <= 10)
            {
                txt.Text = "[ALARM] CRITICAL TANK " + tanknum1 + " has reached critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if (tank2 >= 95 || tank2 <= 10)
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum2 + " has reached critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;

            }
            else
            {
                img.Visible = false;
                txt.Visible = false;
            }


        }
        //alrm thanks on the alarm location
        private void alarmTrigger2(int tank1, int tank2, int tank3, int tanknum1, int tanknum2, int tanknum3, PictureBox img, Label txt)
        
        {
            if ((tank1 >= 95 && tank2 >= 95 && tank3 >= 95) || (tank1 <= 10 && tank2 <= 10 && tank3 <= 10))
            {
                txt.Text = "[ALARM] CRITICAL TANKS" + tanknum1 + "," + tanknum2 + " & TANK " + tanknum3 + " has reached " +
                    "critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if ((tank1 >= 95 && tank2 >= 95) || (tank1 <= 10 && tank2 <= 10))
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum1 + " & TANK " + tanknum2 + " has reached " +
                    "critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if ((tank1 >= 95 && tank3 >= 95) || (tank1 <= 10 && tank3 <= 10))
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum1 + " & TANK " + tanknum3 + " has reached " +
                    "critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if ((tank2 >= 95 && tank3 >= 95) || (tank2 <= 10 && tank3 <= 10))
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum2 + " & TANK " + tanknum3 + " has reached " +
                    "critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if (tank1 >= 95 || tank1 <= 10)
            {
                txt.Text = "[ALARM] CRITICAL TANK " + tanknum1 + " has reached critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;
            }
            else if (tank2 >= 95 || tank2 <= 10)
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum2 + " has reached critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;

            }
            else if (tank3 >= 95 || tank3 <= 10)
            {
                txt.Text = "[ALARM] CRITICAL TANK" + tanknum3 + " has reached critcal  numbers inmmediate action required ";
                img.Visible = true;
                txt.Visible = true;

            }
            else
            {
                img.Visible = false;
                txt.Visible = false;
            }


            

           
        }
        // WARNINGS
        private void warnings(bool warning, PictureBox img, Label txt,string msg)
        {
            if (warning)
            {
                txt.Text = msg;
                img.Visible = true;
                txt.Visible= true;
            }
            else
            {
                img.Visible = false;
                txt.Visible = false;
            }
        }

        /*
         * THIS REPRESENT THE LOG MESSAGES THAT WILL CHANGE AUTOMATICALLY, WHEN YOU PRESS A CONTAINER, IN WILL SHOW THE LOG OF THAT CONTAINER
         */
        int txtStart =1;
        string txtStart1 = "[INFO] SYSTEM STARTED-INITIAL CHECK INITIALIZED ";
        

        private string case3(int num)
        {
            string txt = " ";
            if (logSelector == 3)
            {
                txt = " Valve 3: " + txtPumps(valvePosition3[num]);

            }
            else
            {
                txt = " ";
            }
            return txt;
        }

        
        private void logControl(int[] capacity1,int[] capacity2, bool[] valveStatus, int[] temperature1, int[] temperature2,int[] fanstatus,int one,int two)
        
        {
            
            if (txtStart == 1)
            {
                 /*
                  Every time the code starts the first message of the log is the system started, followed by the information of the
                  elements 
                  */
                txtStart1 = "[INFO] SYSTEM STARTED-INITIAL CHECK INITIALIZED ";
            }
            else
            {
                txtStart1 = "[INFO] HOUR CHECK ";
            }
            if (dateTimes.Length == 1 )
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank "+ one+  " level: " + capacity1[0] + "%" + " Tank "+two+" level: " + capacity2[0] + "%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0])+ case3(0));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + temperature1[0] + "°C " + " Tank " + two + " level: "+temperature2[0] + "°C");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0]);
                TxtIniCont21.Visible = false;
                TxtIniCont22.Visible = false;
                TxtIniCont23.Visible = false;
                TxtIniCont24.Visible = false;
                TxtIniCont25.Visible = false;
                TxtIniCont31.Visible = false;
                TxtIniCont32.Visible = false;
                TxtIniCont33.Visible = false;
                TxtIniCont34.Visible = false;
                TxtIniCont35.Visible = false;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 2)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0])+ case3(0));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + temperature1[0] + "°C " + " Tank " + two + " level: " + temperature2[0] + "°C");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1])+ case3(1));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + temperature1[1] + "°C " + " Tank " + two + " level: " + temperature2[1] + "°C");
                TxtIniCont25.Text = (dateTimes[1] + "[DEBUG] Fan pump " + fanstatus[1]);
                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = false;
                TxtIniCont32.Visible = false;
                TxtIniCont33.Visible = false;
                TxtIniCont34.Visible = false;
                TxtIniCont35.Visible = false;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 3)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "%"); ;
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0]) + case3(0));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + temperature1[0] + "°C " + " Tank " + two + " level: " + temperature2[0] + "°C");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1]) + case3(1));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + temperature1[1] + "°C " + " Tank " + two + " level: " + temperature2[1] + "°C");
                TxtIniCont25.Text = (dateTimes[1] + "[DEBUG] Fan pump " + fanstatus[1]);

                TxtIniCont31.Text = (dateTimes[2] + "[INFO] HOUR CHECK ");
                TxtIniCont32.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + capacity1[2] + "%" + " Tank " + two + " level: " + capacity2[2] + "%");
                TxtIniCont33.Text = (dateTimes[2] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[2]) + case3(2));
                TxtIniCont34.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + temperature1[2] + "°C " + " Tank " + two + " level: " + temperature2[2] + "°C");
                TxtIniCont35.Text = (dateTimes[2] + "[DEBUG] Fan pump " + fanstatus[2]);

                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = true;
                TxtIniCont32.Visible = true;
                TxtIniCont33.Visible = true;
                TxtIniCont34.Visible = true;
                TxtIniCont35.Visible = true;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 4)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0]) + case3(0));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + temperature1[0] + "°C " + " Tank " + two + " level: " + temperature2[0] + "°C");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1]) + case3(1));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + temperature1[1] + "°C " + " Tank " + two + " level: " + temperature2[1] + "°C");
                TxtIniCont25.Text = (dateTimes[1] + "[DEBUG] Fan pump " + fanstatus[1]);

                TxtIniCont31.Text = (dateTimes[2] + "[INFO] HOUR CHECK ");
                TxtIniCont32.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + capacity1[2] + "%" + " Tank " + two + " level: " + capacity2[2] + "%");
                TxtIniCont33.Text = (dateTimes[2] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[2]) + case3(2));
                TxtIniCont34.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + temperature1[2] + "°C " + " Tank " + two + " level: " + temperature2[2] + "°C");
                TxtIniCont35.Text = (dateTimes[2] + "[DEBUG] Fan pump " + fanstatus[2]);

                TxtIniCont41.Text = (dateTimes[3] + "[INFO] HOUR CHECK ");
                TxtIniCont42.Text = (dateTimes[3] + "[DEBUG] Tank " + one + " level: " + capacity1[3] + "%" + " Tank " + two + " level: " + capacity2[3] + "%");
                TxtIniCont43.Text = (dateTimes[3] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[3]) + case3(3));
                TxtIniCont44.Text = (dateTimes[3] + "[DEBUG] Tank " + one + " level: " + temperature1[3] + "°C " + " Tank " + two + " level: " + temperature2[3] + "°C");
                TxtIniCont45.Text = (dateTimes[3] + "[DEBUG] Fan pump " + fanstatus[3]);


                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = true;
                TxtIniCont32.Visible = true;
                TxtIniCont33.Visible = true;
                TxtIniCont34.Visible = true;
                TxtIniCont35.Visible = true;
                TxtIniCont41.Visible = true;
                TxtIniCont42.Visible = true;
                TxtIniCont43.Visible = true;
                TxtIniCont44.Visible = true;
                TxtIniCont45.Visible = true;
            }

        }
       
        //DUE THAT THERE ARE MORE THINGS TO ADD ON THE LAST CONTAINER, IT HAS HIS OWN METHOD TO BE SHOWN IN THE LOG  
        private void logControl4(int[] capacity1, int[] capacity2,int[] capacity3, bool[] valveStatus,bool[] valveStatus2, int[] temperature1, int[] temperature2,int[] temperature3,
            int[] fanstatus,int[] fanstatus2, int one, int two, int three, bool[] pump)
        {
         
            if (txtStart == 1)
            {
                txtStart1 = "[INFO] SYSTEM STARTED-INITIAL CHECK INITIALIZED ";
            }
            else
            {
                txtStart1 = "[INFO] HOUR CHECK ";
            }
            if (dateTimes.Length == 1)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "% Tank "+ three 
                    +" level: " + capacity3[0]+"%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0])+ " Pump A2: "+ txtPumps(valveStatus2[0])+" Valve 1: " + txtPumps(pump[0]));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " temperature: " + temperature1[0] + "°F " + " Tank " + two + " temperature: " + temperature2[0] +
                    "°F Tank "+three+ " "+ temperature3[0]+"°F");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0]+" Fan pump 2: "+ fanstatus2[0]);
                TxtIniCont21.Visible = false;
                TxtIniCont22.Visible = false;
                TxtIniCont23.Visible = false;
                TxtIniCont24.Visible = false;
                TxtIniCont25.Visible = false;
                TxtIniCont31.Visible = false;
                TxtIniCont32.Visible = false;
                TxtIniCont33.Visible = false;
                TxtIniCont34.Visible = false;
                TxtIniCont35.Visible = false;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 2)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "% Tank " + three
                    + " level: " + capacity3[0] + "%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0]) + " Pump A2: " + txtPumps(valveStatus2[0]) + " Valve 1: " + txtPumps(pump[0]));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " temperature: " + temperature1[0] + "°F " + " Tank " + two + " temperature: " + temperature2[0] +
                    "°F Tank " + three + " " + temperature3[0] + "°F");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0] + " Fan pump 2: " + fanstatus2[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "% Tank " + three
                    + " level: " + capacity3[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1]) + " Pump A2: " + txtPumps(valveStatus2[1]) + " Valve 1: " + txtPumps(pump[1]));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " temperature: " + temperature1[1] + "°F " + " Tank " + two + " temperature: " + temperature2[1] +
                    "°F Tank " + three + " " + temperature3[1] + "°F");
                TxtIniCont25.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[1] + " Fan pump 2: " + fanstatus2[1]);
                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = false;
                TxtIniCont32.Visible = false;
                TxtIniCont33.Visible = false;
                TxtIniCont34.Visible = false;
                TxtIniCont35.Visible = false;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 3)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "% Tank " + three
                    + " level: " + capacity3[0] + "%"); 
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0]) + " Pump A2: " + txtPumps(valveStatus2[0]) + " Valve 1: " + txtPumps(pump[0]));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " temperature: " + temperature1[0] + "°F " + " Tank " + two + " temperature: " + temperature2[0] +
                    "°F Tank " + three + " " + temperature3[0] + "°F");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0] + " Fan pump 2: " + fanstatus2[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "% Tank " + three
                    + " level: " + capacity3[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1]) + " Pump A2: " + txtPumps(valveStatus2[1]) + " Valve 1: " + txtPumps(pump[1]));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " temperature: " + temperature1[1] + "°F " + " Tank " + two + " temperature: " + temperature2[1] +
                    "°F Tank " + three + " " + temperature3[1] + "°F");
                TxtIniCont25.Text = (dateTimes[1] + "[DEBUG] Fan pump " + fanstatus[1] + " Fan pump 2: " + fanstatus2[1]);

                TxtIniCont31.Text = (dateTimes[2] + "[INFO] HOUR CHECK ");
                TxtIniCont32.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + capacity1[2] + "%" + " Tank " + two + " level: " + capacity2[2] + "% Tank " + three
                    + " level: " + capacity3[2] + "%");
                TxtIniCont33.Text = (dateTimes[2] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[2]) + " Pump A2: " + txtPumps(valveStatus2[2]) + " Valve 1: " + txtPumps(pump[2]));
                TxtIniCont34.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " temperature: " + temperature1[2] + "°F " + " Tank " + two + " temperature: " + temperature2[2] +
                    "°F Tank " + three + " " + temperature3[2] + "°F");
                TxtIniCont35.Text = (dateTimes[2] + "[DEBUG] Fan pump " + fanstatus[2] + " Fan pump 2: " + fanstatus2[2]);

                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = true;
                TxtIniCont32.Visible = true;
                TxtIniCont33.Visible = true;
                TxtIniCont34.Visible = true;
                TxtIniCont35.Visible = true;
                TxtIniCont41.Visible = false;
                TxtIniCont42.Visible = false;
                TxtIniCont43.Visible = false;
                TxtIniCont44.Visible = false;
                TxtIniCont45.Visible = false;
            }
            if (dateTimes.Length == 4)
            {
                TxtIniCont11.Text = (dateTimes[0] + txtStart1);
                TxtIniCont12.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " level: " + capacity1[0] + "%" + " Tank " + two + " level: " + capacity2[0] + "% Tank " + three
                    + " level: " + capacity3[0] + "%");
                TxtIniCont13.Text = (dateTimes[0] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[0]) + " Pump A2: " + txtPumps(valveStatus2[0]) + " Valve 1: " + txtPumps(pump[0]));
                TxtIniCont14.Text = (dateTimes[0] + "[DEBUG] Tank " + one + " temperature: " + temperature1[0] + "°F " + " Tank " + two + " temperature: " + temperature2[0] +
                    "°F Tank " + three + " " + temperature3[0] + "°F");
                TxtIniCont15.Text = (dateTimes[0] + "[DEBUG] Fan pump " + fanstatus[0] + " Fan pump 2: " + fanstatus2[0]);


                TxtIniCont21.Text = (dateTimes[1] + "[INFO] HOUR CHECK ");
                TxtIniCont22.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " level: " + capacity1[1] + "%" + " Tank " + two + " level: " + capacity2[1] + "% Tank " + three
                    + " level: " + capacity3[1] + "%");
                TxtIniCont23.Text = (dateTimes[1] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[1]) + " Pump A2: " + txtPumps(valveStatus2[1]) + " Valve 1: " + txtPumps(pump[1]));
                TxtIniCont24.Text = (dateTimes[1] + "[DEBUG] Tank " + one + " temperature: " + temperature1[1] + "°F " + " Tank " + two + " temperature: " + temperature2[1] +
                    "°F Tank " + three +" " + temperature3[1] + "°F");
                TxtIniCont25.Text = (dateTimes[1] + "[DEBUG] Fan pump " + fanstatus[1] + " Fan pump 2: " + fanstatus2[1]);

                TxtIniCont31.Text = (dateTimes[2] + "[INFO] HOUR CHECK ");
                TxtIniCont32.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " level: " + capacity1[2] + "%" + " Tank " + two + " level: " + capacity2[2] + "% Tank " + three
                    + " level: " + capacity3[2] + "%");
                TxtIniCont33.Text = (dateTimes[2] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[2]) + " Pump A2: " + txtPumps(valveStatus2[2]) + " Valve 1: " + txtPumps(pump[2]));
                TxtIniCont34.Text = (dateTimes[2] + "[DEBUG] Tank " + one + " temperature: " + temperature1[2] + "°F " + " Tank " + two + " temperature: " + temperature2[2] +
                    "°F Tank " + three +" " + temperature3[2] + "°F");
                TxtIniCont35.Text = (dateTimes[2] + "[DEBUG] Fan pump " + fanstatus[2] + " Fan pump 2: " + fanstatus2[2]);

                TxtIniCont41.Text = (dateTimes[3] + "[INFO] HOUR CHECK ");
                TxtIniCont42.Text = (dateTimes[3] + "[DEBUG] Tank " + one + " level: " + capacity1[3] + "%" + " Tank " + two + " level: " + capacity2[3] + "% Tank " + three
                    + " level: " + capacity3[3] + "%");
                TxtIniCont43.Text = (dateTimes[3] + "[DEBUG] Pump A1: " + txtPumps(valveStatus[3]) + " Pump A2: " + txtPumps(valveStatus2[3]) + " Valve 1: " + txtPumps(pump[3]));
                TxtIniCont44.Text = (dateTimes[3] + "[DEBUG] Tank " + one + " temperature: " + temperature1[3] + "°F " + " Tank " + two + " temperature: " + temperature2[3] +
                    "°F Tank " + three  +" "+ temperature3[3] + "°F");
                TxtIniCont45.Text = (dateTimes[3] + "[DEBUG] Fan pump " + fanstatus[3] + " Fan pump 2: " + fanstatus2[3]);


                TxtIniCont21.Visible = true;
                TxtIniCont22.Visible = true;
                TxtIniCont23.Visible = true;
                TxtIniCont24.Visible = true;
                TxtIniCont25.Visible = true;
                TxtIniCont31.Visible = true;
                TxtIniCont32.Visible = true;
                TxtIniCont33.Visible = true;
                TxtIniCont34.Visible = true;
                TxtIniCont35.Visible = true;
                TxtIniCont41.Visible = true;
                TxtIniCont42.Visible = true;
                TxtIniCont43.Visible = true;
                TxtIniCont44.Visible = true;
                TxtIniCont45.Visible = true;
            }

        }
        /*
         * THE CODE BELOW REPRESENTS A MENU IN WHICH DEPENDING ON THE CONTAINER PRESS, 
         * THE LOG WILL DIPLAY THE RESPECTIVE MESSAGE 
         * */
        private void logQuery()
        {
            switch (logSelector)
            {
                case 1:
                    logControl(graphCapacity9, graphCapacity4, valveStatusContainer1, temperatureTank9, temperatureTank4, fanSatusConatiner1, 9, 4);
                    break;
                case 2:
                    logControl(graphCapacity5, graphCapacity3, valveStatusContainer2, temperatureTank5, temperatureTank3, fanSatusConatiner2, 5, 3);
                    break;
                case 3:
                    logControl(graphCapacity1, graphCapacity2, valveStatusContainer3, temperatureTank1, temperatureTank2, fanSatusConatiner3, 1, 2);
                    break;
                case 4:
                    logControl4(graphCapacity6, graphCapacity7, graphCapacity8, valveStatusContainer4, valveStatusContainer5,
                        temperatureTank6, temperatureTank7, temperatureTank8, fanSatusConatiner4, fanSatusConatiner5, 6, 7, 8, valvePosition4);
                    break;
            }
        }

        /*
         * WHEN YOU CLICK A CONTAINER, THE VALUE OF THE MENU WILL CHANGE AS WELL
         * 
         */
        private void container2_Click(object sender, EventArgs e)
        {
            logSelector = 1;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            logSelector = 2;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            logSelector = 3;
        }

        private void Panel4_MouseClick(object sender, MouseEventArgs e)
        {
            logSelector = 4;
        }
    }

}
