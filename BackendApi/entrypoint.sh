#!/bin/bash

dotnet ef database update
dotnet watch --non-interactive --launch-profile Docker
