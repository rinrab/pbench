#pragma once

using namespace System;

ref class ProcessStats
{
public:
    property TimeSpan^ RealTime
    {
        TimeSpan^ get() { return realTime; }
        void set(TimeSpan^ value) { realTime = value; }
    }

    property TimeSpan^ CpuTime
    {
        TimeSpan^ get() { return cpuTime; }
        void set(TimeSpan^ value) { cpuTime = value; }
    }

    property TimeSpan^ UserTime
    {
        TimeSpan^ get() { return userTime; }
        void set(TimeSpan^ value) { userTime = value; }
    }

    property TimeSpan^ KernelTime
    {
        TimeSpan^ get() { return kernelTime; }
        void set(TimeSpan^ value) { kernelTime = value; }
    }

    property TimeSpan^ TotalTime
    {
        TimeSpan^ get() { return kernelTime; }
        void set(TimeSpan^ value) { kernelTime = value; }
    }

    property long ReadCount
    {
        long get() { return readCount; }
        void set(long value) { readCount = value; }
    }

    property long ReadBytes
    {
        long get() { return readBytes; }
        void set(long value) { readBytes = value; }
    }

    property long WriteCount
    {
        long get() { return writeCount; }
        void set(long value) { writeCount = value; }
    }

    property long WriteBytes
    {
        long get() { return writeBytes; }
        void set(long value) { writeBytes = value; }
    }

private:
    TimeSpan^ realTime;
    TimeSpan^ cpuTime;
    TimeSpan^ userTime;
    TimeSpan^ kernelTime;
    TimeSpan^ totalTime;
    long readCount;
    long readBytes;
    long writeCount;
    long writeBytes;
};
