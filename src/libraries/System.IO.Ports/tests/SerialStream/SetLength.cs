// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.IO.PortsTests;
using Legacy.Support;
using Xunit;

namespace System.IO.Ports.Tests
{
    public class SerialStream_SetLength : PortsTest
    {
        private const int DEFAULT_VALUE = 0;
        private const int BAD_VALUE = -1;

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void SetLength_Open_Close()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Stream serialStream = com.BaseStream;
                com.Close();

                Debug.WriteLine("Verifying SetLength property throws exception After Open() then Close()");

                Assert.Throws<NotSupportedException>(() => serialStream.SetLength(DEFAULT_VALUE));
            }
        }

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void SetLength_Open_BaseStreamClose()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Stream serialStream = com.BaseStream;
                com.BaseStream.Close();

                Debug.WriteLine("Verifying SetLength property throws exception After Open() then BaseStream.Close()");

                Assert.Throws<NotSupportedException>(() => serialStream.SetLength(DEFAULT_VALUE));
            }
        }

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void SetLength_AfterOpen()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Debug.WriteLine("Verifying SetLength method throws exception after a call to Open()");

                Assert.Throws<NotSupportedException>(() => com.BaseStream.SetLength(DEFAULT_VALUE));
            }
        }

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void SetLength_BadValue()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();

                Debug.WriteLine("Verifying SetLength method throws exception with a bad value after a call to Open()");

                Assert.Throws<NotSupportedException>(() => com.BaseStream.SetLength(BAD_VALUE));
            }
        }
    }
}
