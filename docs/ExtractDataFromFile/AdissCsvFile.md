# ADISS CSV File

## File Header
The following items represent each line at the start of the ADISS CSV file.

1. Project Name
    - Example: 
``` 
Project: 2018 Freeport LNG Maintenance Dredging Project 
```
2. Permit Code
    - Example: 
```
Permit: SWG-2013-00147
```
3. Client Name
    - Example: 
```
Client: Great Lakes Dredge & Dock Co.
```
4. Trip Number
    - Example: 
```
Trip: 51
```
5. Scow Vessel Name
    - The scow vessel name.
    - Example: 
```
Vessel Name: GL61
```
6. Material Source
    - Example: 
```
Material Source: UNKNOWN
```
7. Transit Start
    - Example: 
```
Transit Start: 4/25/2018 7:01:55 PM
```
8. Disposal Start
    - Example: 
```
Disposal Start: 4/25/2018 8:00:55 PM
```
9. Note
    - Example: 
```
Note: Coordinates are in NAD 1983 StatePlane Texas South Central FIPS 4204 Feet
```
10. Line Separation
    - A single empty line to separate the [file header](#file-header) and [records](#records).
11. Record Header
    - The line populated by the header of the [records](#records):
```
Local Date/Time,Easting,Northing,Heading,Speed (knots),Aft Draft (ft),Fore Draft (ft),Aft Ullage (ft),ForeUllage (ft),Water Depth (ft),Placement Phase,Hull Status
```

## Records
The following items represent each field/column of the data starting from line 12 of the ADISS CSV file.

1. Local Date Time
    - A date/time value.
2. Easting
    - A double value of easting in international feet.
3. Northing
    - A double value of northing in international feet.
4. Heading
    - A double value of heading in decimal degrees.
5. Speed
    - A double value of speed in knots.
6. Aft Draft
    - A double value of aft draft in international feet.
7. Fore Draft
    - A double value of fore draft in international feet.
8. Aft Ullage
    - A double value of aft ullage in international feet.
9. Fwd Ullage
    - A double value of fore ullage in international feet.
10. Water Depth
    - A nullable double value of water depth in international feet.
    - `null` is printed as `N/A`.
11. [Placement Phase](../PlacementPhase.md)
12. [Hull Status](../HullStatus.md)
    - Upper case only