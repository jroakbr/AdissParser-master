# Output Data
1. ADISS Load #
    - The [Trip Number](/ExtractDataFromFile/AdissCsvFile.md).
2. Dredge Load Number
    - A user input.
3. [Dredge](Dredge.md) Name
    - A user input.
4. Scow Vessel Name
    - The [Scow Vessel Name](/ExtractDataFromFile/AdissCsvFile.md).
5. Tug Vessel Name
    - A user input.
6. Disposal Area
    - A user input.
7. Average Draft Loss During Transit To Disposal Area
    - A nullable double value that represents the difference of the average of `Aft` and `Fore` `Draft` when the scow starts transiting to the disposal area and when it enters the disposal area.  
    - The first `Placement Phase = TRANSIT` record is when the scow starts transiting to the disposal area.
    - The first `Placement Phase = TRANSIT` record where the scow is inside the disposal area is when it enters the disposal area.
    - `null` if no record was found where the scow is inside the disposal area.
8. Maximum Speed during [`TRANSIT`](PlacementPhase.md)
    - The maximum speed from all the [records](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = TRANSIT`.
9. Is Start Dump Inside Of Berm
    - A nullable boolean value that represents whether the scow started dumping inside of the berm.
    - `true` if the scow started dumping inside of the berm. `null` if no berm is designated based on the selected dredge (i.e. Dredge New York); otherwise `false`.
    - Is start dump inside berm is `true` if the first `Placement Phase = DISPOSAL` [record](/ExtractDataFromFile/AdissCsvFile.md#records) is inside of the Berm boundary.
10. Is Scow Open Violation
    - Is scow open violation is `true` if any of the `Hull Status = OPEN or Placement Phase = DISPOSAL` records is outside the disposal area boundary; otherwise `false`
11. Is Mis-Dump
    - Is mis-dump is `true` if the start dump (first `Placement Phase = DISPOSAL`) [record](/ExtractDataFromFile/AdissCsvFile.md#records) is outside the disposal area boundary; otherwise `false`.
12. Is Emergency Dump
    - A user input boolean value indicating whether an emergency dump was carried out. `true` if emergency dump was carried out; otherwise `false`.
13. Start loading Date/Time
    - The date/time of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = LOADING`.
14. End loading Date/Time
    - The date/time of the last [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = LOADING`.
15. Start Transit To Disposal Area Date/Time
    - The date/time of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = TRANSIT`.
16. Average Draft Start Transit To Disposal Area
    - The average of `Aft` and `Fore` `Draft` of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = TRANSIT`.
17. Average Draft Entering Disposal Area
    - A nullable double value that represents the average of `Aft` and `Fore` `Draft` of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) when the scow is within the disposal area.
    - `null` if no records were found where the scow is inside the disposal area.
18. Start Dump X
    - The x coordinate of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
19. Start Dump Y
    - The y coordinate of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
20. Start Dump Date/Time
    -  The date/time of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
21. End Dump X
    - The x coordinate of the last [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
22. End Dump Y
    - The y coordinate of the last [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
23. End Dump Date/Time
    - The date/time of the last [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = DISPOSAL`.
24. Average Draft Leaving The Channel
    - A nullable double value that represents the average of `Aft` and `Fore` `Draft` when the scow leaves the channel. The scow is considered to have left the channel at the instant it went outside the channel and never comes back in again while in `TRANSIT`.
    - `null` if all the x/y records `Placement Phase = TRANSIT` is outside the channel.
25. End Return From Disposal Area Date/Time
    - The date/time of the last [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = RETURN`.
26. Total Transit Duration
    - The difference of the date/time between the first and last [records](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = TRANSIT`. 
27. Estimated Load
    - The volume when the scow starts transiting to the disposal area.
    - Looks up the volume using the average of `Aft` and `Fore` `Draft` of the first [record](/ExtractDataFromFile/AdissCsvFile.md#records) where `Placement Phase = TRANSIT`.
28. Start Transit To Disposal Area Dredge Dig X
    - The x-coordinate of the dredge dig location when the scow starts transiting to the disposal area.
    - Dredge record is parsed from [CSD MDB](ExtractDataFromFile/CsdMdbQuerying.md) or [Dredge New York DRG](ExtractDataFromFile/DrgParsing.md) file/s.
        - Dredge Record DateTime should be greater than or equal the looked up DateTime and not later than 10 seconds.
29. Start Transit To Disposal Area Dredge Dig Y
30. Start Transit To Disposal Area Dredge Dig Depth
31. Start Transit To Disposal Area Dredge Dig Station