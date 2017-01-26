#!/bin/bash

ProjectName="BioGorod"
BinDir=../$ProjectName/bin/Debug

# Очистка бин от лишний файлов

rm -v ${BinDir}/*.mdb

cp -r -v ${BinDir}/* ./Files

wine ~/.wine/drive_c/Program\ Files\ \(x86\)/NSIS/makensis.exe /INPUTCHARSET UTF8 ${ProjectName}.nsi
