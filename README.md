# CashReg

## Overview

This is a sample dotnet core console app. This program simulates a cash register. This was created as an exercise for a Job Interview.

Design and implement a cash register.

The 3 main requirements are:
1. It needs to be able to scan items in by quantity and weight

2. It needs to be able to handle discount coupons… allow for two different types of coupons

    * % off total

    * Buy ‘x’ get ‘y’ free (i.e. buy 3 get 1 free)

3. It should be able to provide a caller with a total cost and a list of items

## Assumptions

I assume that user input will more or less follow the expected input, some error and bounds checking are involved but not everything is covered.

I assume that only a single percentage off coupon can be used the latest coupon scanned will be used.

I assume that a single item can only have a single coupon associated to it. Any additional coupons added for the same item replace the old item.

I assume that resonable values will be input.

I assume that item names are a single word without spaces.

I assume that the user will be using the command line.

I assume that you can have both a single percent coupon and multiple BXGY coupons.

I assume that the order of applying discounts matters and all BXGY coupons are applied first and lastly is the percentage coupon.

I assume for BXGY coupons that they apply to multiples of items, e.g. a Buy One Get One on 4 items results in 2 free items.

I assume the same currency is used for all items.

## Build

To build run:

~~~sh
cd src
dotnet build
~~~
## Test

### All tests

~~~sh
cd tests
dotnet test
~~~

### Some tests

~~~sh
cd tests
dotnet test --filter Converter
~~~

## Publish

To publish the project for a particular platform run one of the following.

### Windows

#### Portable

~~~sh
cd src
dotnet publish -r win-x86
-- or --
dotnet publish -r win-x64
~~~

#### Windows 7

~~~sh
cd src
dotnet publish -r win7-x86
-- or ---
dotnet publish -r win7-x64
~~~

### Windows 8

~~~sh
cd src
dotnet publish -r win8-x86
-- or --
dotnet publish -r win8-x64
-- or ---
dotnet publish -r win8-arm
~~~

#### Windows 8.1

~~~sh
cd src
dotnet publish -r win81-x86
-- or --
dotnet publish -r win81-x64
-- or ---
dotnet publish -r win81-arm
~~~

#### Windows 10


~~~sh
cd src
dotnet publish -r win10-x86
-- or --
dotnet publish -r win10-x64
-- or ---
dotnet publish -r win10-arm
-- or ---
dotnet publish -r win10-arm64
~~~

### Linux

#### Portable

~~~sh
cd src
dotnet publish -r linux-x64
~~~

#### CentOS

~~~sh
cd src
dotnet publish -r centos-x64
-- or --
dotnet publish -r centos.7-x64
~~~

#### Debian

~~~sh
cd src
dotnet publish -r debian-x64
-- or --
dotnet publish -r debian.8-x64
~~~

#### Fedora

~~~sh
cd src
dotnet publish -r fedora-x64
-- or --
dotnet publish -r fedora.24-x64
-- or --
dotnet publish -r fedora.25-x64
-- or --
dotnet publish -r fedora.26-x64
~~~

#### Additional Distros

For publishing to additional linux distros see [microsoft](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog "Dotnet core publish reference").

### MacOS

~~~sh
cd src
dotnet publish -r osx-x64 # netcore2.0 and later
-- or --
dotnet publish -r osx10.10-x64
-- or --
dotnet publish -r osx10.11-x64
-- or --
dotnet publish -r osx10.12-x64 # netcore1.1 and later
-- or --
dotnet publish -r osx10.13-x64
~~~

## Usage

### Run the app

~~~sh
cd src
dotnet run
~~~

### Initial Prompt

~~~sh
Welcome to CashReg type "help" to see more info
help, scan, total, coupon, exit ?
~~~

### Help

Entering "help" writes out to the screen a list of availavle commands.

```
help, scan, total, coupon, exit ? help
Please use any of [help, scan, total, coupon, exit]
You'll be prompted for additional details if necessary

help, scan, total, coupon, exit ?
```

### Scan

Entering "scan" you will be asked to enter more information:

~~~sh
item >
~~~

The input to the scan is in the format `XX name DD` where `XX` is the quantity or weight of the `name` item and `DD` is the value of the of item with per-unit if its a quantity item or per weight measure.

e.g.
```sh
item > 1 apple 1.99
Added 1 apple@1.99
...
item > 2.5 orange 0.99
Added 2.5 orange@0.99
```
### Coupon

Entering "coupon" command brings up the promt:

```sh
help, scan, total, coupon, exit ? coupon
coupon >
```

The format of this line is <coupon_type> <options> ... where coupon_type is either '%' or 'BXGY' (for buy X get Y)

#### BOGO example

```
help, scan, total, coupon, exit ? coupon
coupon > BXGY apple 1 1
```

### Total

The "total" command prints all items that have benn scanned into the register.

e.g.

```
help, scan, total, coupon, exit ? total
CashReg Currrent Total
        2 Unique Items
        1 apple@1.99
        2.5 orange@0.99

SubTotal: 4.465  Discount: 0
Total: 4.465

help, scan, total, coupon, exit ?
```


### Exit

Entering "exit" closes the application