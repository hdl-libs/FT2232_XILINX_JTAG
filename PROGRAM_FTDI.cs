using System;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FTD2XX_NET;
using static FTD2XX_NET.FTDI;

namespace WindowsFormsApp1
{
    public partial class PROGRAM_FTDI : Form
    {
        string DEFAULT_VENDOR = "my vendor co";
        string DEFAULT_BOARD = "my board";
        string DEFAULT_MANUFACTURER = "Xilinx";
        string DEFAULT_PRODUCT = "my product desc";
        string DEFAULT_SERIAL = "0ABC01";

        public enum FTDI_PID : UInt16
        {
            FT232H = 24596,
            FT2232H = 24592,
            FT4232H = 24593,
        }

        public struct FTDI_PID_PART
        {
            public UInt16 ProductID;
            public UInt16 ChannleNum;
            public UInt32 FirmwareId;
        }

        private FTDI_PID_PART[] ftdi_pid_parts = new FTDI_PID_PART[3] {
            new FTDI_PID_PART{ ProductID = (ushort)FTDI_PID.FT232H, ChannleNum = 1, FirmwareId = 0x584a0002},
            new FTDI_PID_PART{ ProductID = (ushort)FTDI_PID.FT2232H, ChannleNum = 2, FirmwareId = 0x584a0003},
            new FTDI_PID_PART{ ProductID = (ushort)FTDI_PID.FT4232H, ChannleNum = 4, FirmwareId = 0x584a0004},
        };

        FTDI.FT4232H_EEPROM_STRUCTURE ft4232_eeprom_structure = new FTDI.FT4232H_EEPROM_STRUCTURE
        {
            VendorID = 1027,
            ProductID = 24593,
            MaxPower = 100,
            SerNumEnable = true,
            ADriveCurrent = 4,
            BDriveCurrent = 4,
            CDriveCurrent = 4,
            DDriveCurrent = 4,
            AIsVCP = true,
            BIsVCP = true,
            CIsVCP = true,
            DIsVCP = true,
        };

        FTDI.FT2232H_EEPROM_STRUCTURE ft2232_eeprom_structure = new FTDI.FT2232H_EEPROM_STRUCTURE
        {
            VendorID = 1027,
            ProductID = 24592,
            MaxPower = 100,
            SerNumEnable = true,
            ALDriveCurrent = 4,
            AHDriveCurrent = 4,
            BLDriveCurrent = 4,
            BHDriveCurrent = 4,
            IFAIsFifo = true,
            AIsVCP = true,
            BIsVCP = true,
        };

        FTDI.FT232H_EEPROM_STRUCTURE ft232_eeprom_structure = new FTDI.FT232H_EEPROM_STRUCTURE
        {
            VendorID = 1027,
            ProductID = 24596,
            MaxPower = 100,
            SerNumEnable = true,
            ACDriveCurrent = 4,
            ADDriveCurrent = 4,
            IsFifo = true,
        };

        FT_DEVICE_INFO_NODE[] ftdiDeviceList;
        FTDI myFtdiDevice = null;
        ResourceManager rm = new ResourceManager("YourNamespace.Resources", typeof(PROGRAM_FTDI).Assembly);

        public PROGRAM_FTDI()
        {
            InitializeComponent();

            // 检查当前系统语言是否为中文
            if (CultureInfo.CurrentUICulture.Name != "zh-CN")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }

            tb_vendor.Text = DEFAULT_VENDOR;
            tb_board.Text = DEFAULT_BOARD;

            tb_manufacturer.Text = DEFAULT_MANUFACTURER;
            tb_product.Text = DEFAULT_PRODUCT;
            tb_serial.Text = DEFAULT_SERIAL;

            myFtdiDevice = new FTDI();

            GetDeviceList();
        }

        public bool GetDeviceList()
        {
            if(myFtdiDevice.IsOpen)
                return false;

            uint ftdiDeviceCount = 0;
            
            tb_log.Clear();
            cbx_device.Items.Clear();
            
            if (FTDI.FT_STATUS.FT_OK == myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount))
            {
                if (ftdiDeviceCount == 0)
                {
                    tb_log.AppendText("no devices found" + Environment.NewLine);
                    return false;
                }
                tb_log.AppendText("Number of FTDI devices: " + ftdiDeviceCount.ToString() + Environment.NewLine);
            }
            else
            {
                tb_log.AppendText("Failed to get number of devices" + Environment.NewLine);
                return false;
            }

            ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            if (FTDI.FT_STATUS.FT_OK != myFtdiDevice.GetDeviceList(ftdiDeviceList))
            {
                tb_log.AppendText("Failed to get device list" + Environment.NewLine);
                ftdiDeviceList = null;
                return false;
            }

            cbx_device.Items.Clear();
            for (UInt32 i = 0; i < ftdiDeviceCount; i++)
            {
                tb_log.AppendText("Device Index: " + i.ToString() + Environment.NewLine);
                tb_log.AppendText("Type: " + ftdiDeviceList[i].Type.ToString() + Environment.NewLine);
                tb_log.AppendText("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID) + Environment.NewLine);
                tb_log.AppendText("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId) + Environment.NewLine);
                tb_log.AppendText("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString() + Environment.NewLine);
                tb_log.AppendText("Description: " + ftdiDeviceList[i].Description.ToString() + Environment.NewLine);
                tb_log.AppendText(Environment.NewLine);
                cbx_device.Items.Add(ftdiDeviceList[i].SerialNumber);
            }
            
            cbx_device.SelectedIndex = 0;
            
            return true;
        }

        public bool Open_device(int id)
        {
            if(myFtdiDevice.IsOpen)
                return false;

            if(ftdiDeviceList == null)
            {
                tb_log.AppendText("select device first" + Environment.NewLine);
                return false; 
            }

            if (ftdiDeviceList.Length <= id || id < 0) {
                id = 0;
            }

            // myFtdiDevice.OpenByLocation(ftdiDeviceList[0].LocId);
            if (FTDI.FT_STATUS.FT_OK != myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[id].SerialNumber))
            {
                tb_log.AppendText("Failed to open device" + Environment.NewLine);
                return false;
            }

            string serial;
            myFtdiDevice.GetSerialNumber(out serial);
            tb_log.AppendText("设备"+ serial.ToString() +"打开成功！" + Environment.NewLine);

            return true;
        }
       
        public bool Write_eep_info()
        {
            if (!myFtdiDevice.IsOpen)
                return false;

            bool ret = true;

            string manufacturer_string = tb_manufacturer.Text;
            string product_string = tb_product.Text;
            string serial_string = tb_serial.Text;

            FTDI_PID_PART ftdi_pid_part = ftdi_pid_parts[0];

            ret = FT_STATUS.FT_OK == myFtdiDevice.EraseEEPROM();

            if (ret)
            {
                string serial = cbx_device.SelectedItem.ToString();
                char lastChar = serial[serial.Length - 1];

                FTDI.FT_DEVICE deviceType = FTDI.FT_DEVICE.FT_DEVICE_UNKNOWN;
                myFtdiDevice.GetDeviceType(ref deviceType);
                if (deviceType == FTDI.FT_DEVICE.FT_DEVICE_4232H)
                {
                    FTDI.FT4232H_EEPROM_STRUCTURE eeprom_structure = ft4232_eeprom_structure;
                    ftdi_pid_part = ftdi_pid_parts[2];
                    eeprom_structure.ManufacturerID = "";
                    eeprom_structure.Manufacturer = manufacturer_string;
                    eeprom_structure.Description = product_string;
                    eeprom_structure.SerialNumber = serial_string;

                    switch (lastChar)
                    {
                        case 'B':
                            eeprom_structure.BIsVCP = false;
                            break;
                        case 'C':
                            eeprom_structure.CIsVCP = false;
                            break;
                        case 'D':
                            eeprom_structure.DIsVCP = false;
                            break;
                        case 'A':
                        default:
                            eeprom_structure.AIsVCP = false;
                            break;
                    }

                    ret = FT_STATUS.FT_OK == myFtdiDevice.WriteFT4232HEEPROM(eeprom_structure);
                }
                else if (deviceType == FTDI.FT_DEVICE.FT_DEVICE_2232H)
                {
                    FTDI.FT2232H_EEPROM_STRUCTURE eeprom_structure = ft2232_eeprom_structure;
                    ftdi_pid_part = ftdi_pid_parts[1];
                    eeprom_structure.ManufacturerID = "";
                    eeprom_structure.Manufacturer = manufacturer_string;
                    eeprom_structure.Description = product_string;
                    eeprom_structure.SerialNumber = serial_string;

                    switch (lastChar)
                    {
                        case 'B':
                            eeprom_structure.BIsVCP = false;
                            break;
                        case 'A':
                        default:
                            eeprom_structure.AIsVCP = false;
                            break;
                    }

                    ret = FT_STATUS.FT_OK == myFtdiDevice.WriteFT2232HEEPROM(eeprom_structure);
                }
                else if (deviceType == FTDI.FT_DEVICE.FT_DEVICE_232H)
                {
                    FTDI.FT232H_EEPROM_STRUCTURE eeprom_structure = ft232_eeprom_structure;
                    ftdi_pid_part = ftdi_pid_parts[0];
                    eeprom_structure.ManufacturerID = "";
                    eeprom_structure.Manufacturer = manufacturer_string;
                    eeprom_structure.Description = product_string;
                    eeprom_structure.SerialNumber = serial_string;
                    ret = FT_STATUS.FT_OK == myFtdiDevice.WriteFT232HEEPROM(eeprom_structure);
                }
            }

            if (ret)
            {
                uint userAreaSize = 0;
                ret = FT_STATUS.FT_OK == myFtdiDevice.EEUserAreaSize(ref userAreaSize);

                byte[] userAreaData = new byte[userAreaSize];

                // 将整数转换为4字节数组
                byte[] fwidBytes = BitConverter.GetBytes(ftdi_pid_part.FirmwareId);
                byte[] vendorBytes = Encoding.ASCII.GetBytes(tb_vendor.Text + '\0');
                byte[] productBytes = Encoding.ASCII.GetBytes(tb_board.Text + '\0');

                Buffer.BlockCopy(fwidBytes, 0, userAreaData, 0, fwidBytes.Length);
                Buffer.BlockCopy(vendorBytes, 0, userAreaData, fwidBytes.Length, vendorBytes.Length);
                Buffer.BlockCopy(productBytes, 0, userAreaData, fwidBytes.Length + vendorBytes.Length, productBytes.Length);
                myFtdiDevice.EEWriteUserArea(userAreaData);

                myFtdiDevice.ResetPort();
            }

            return ret;
        }

        private void Btn_Write_Click(object sender, EventArgs e)
        {
            if (!myFtdiDevice.IsOpen)
            {
                tb_log.AppendText("请先打开设备！" + Environment.NewLine);
                return;
            }

            if(Write_eep_info())
                tb_log.AppendText("数据写入成功！" + Environment.NewLine);
        }

        private void Btn_Close_click(object sender, EventArgs e)
        {
            if (myFtdiDevice.IsOpen)
            {
                myFtdiDevice.Close();
            }
            tb_log.Clear();
        }

        private void Btn_Open_click(object sender, EventArgs e)
        {
            if (myFtdiDevice.IsOpen)
                return;
            Open_device(cbx_device.SelectedIndex);
        }

        private void Btn_Refresh_click(object sender, EventArgs e)
        {
            if (myFtdiDevice.IsOpen)
                return;
            GetDeviceList();
        }
        
    }
}
