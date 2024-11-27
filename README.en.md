# PROGRAM_FTDI

## Introduction

PROGRAM_FTDI is a Windows Forms application used to set and manage the serial number information of Xilinx JTAG devices based on FT232/FT2232/FT4232.

## Preview

![xilinx_jtag](doc/xilinx_jtag.png)

## Usage Environment

- **Development Tool**: Visual Studio 2022
- **Framework/Library**: .NET Framework v4.8
- **Dependency Library**: FTD2XX_NET

## Key Points

1. The key point for being recognized by Xilinx tools as a JTAG device lies in the FirmwareId field in the user area, which is determined based on the chip model.
2. The user area also stores the Vendor string and Board string.
3. After erasing, use FTDI's EEPROM write API to normally write the EEPROM, then use the UserArea write API to write "FirmwareId + Vendor + Board".
4. If the chip has multiple ports, Xilinx tools only use Port A as JTAG, even if you modify whether the port uses VCP.

## References

1. [Xilinx JTAG Support on FTDI](https://etherealwake.com/2024/06/xilinx-ftdi-jtag/)

    This article describes the eeprom data structure.

2. [ug908-vivado-programming-debugging](https://docs.amd.com/r/en-US/ug908-vivado-programming-debugging/Programming-FTDI-Devices-for-Vivado-Hardware-Manager-Support)

    This document describes how to program FTDI devices as JTAG devices.