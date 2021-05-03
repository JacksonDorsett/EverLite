#! /bin/bash -x
cd EverLite
pwd
cp waves.json "bin/Debug/netcoreapp3.1/waves.json"
cp MovementPreset.json "bin/Debug/netcoreapp3.1/MovementPreset.json"
cp ShootingPatternPresets.json "bin/Debug/netcoreapp3.1/ShootingPatternPresets.json"
echo "Moved scripts to the bin folder"
