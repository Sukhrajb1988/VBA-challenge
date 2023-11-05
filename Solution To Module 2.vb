Sub stock_solver():

Dim GreatestIncreaseTicker As String
Dim GreatestDecreaseTicker As String
Dim GreatestTotalTicker As String
Dim GreatestIncrease As Double
Dim GreatestDecrease As Double
Dim GreatestTotal As Double

Dim ws As Worksheet
Dim total As Double
Dim i As Long
Dim YearlyChange As Double
Dim SUKI As Integer
Dim start As Long
Dim LastRow As Long
Dim PerChange As Double
Dim days As Integer


   
   
   For Each ws In Worksheets
      ws.Activate
  
   
   Range("I1").Value = "Ticker"
   Range("J1").Value = "Yearly Change"
   Range("K1").Value = "Percent Change"
   Range("L1").Value = "Total Stock Volume"
   Range("P1").Value = "Ticker"
   Range("Q1").Value = "Value"
   Range("O2").Value = "Greatest % Increase"
   Range("O3").Value = "Greatest % Decrease"
   Range("O4").Value = "Greatest Total Volume"
   
   
   SUKI = 0
   total = 0
   YearlyChange = 0
   start = 2
   
   LastRow = Cells(Rows.Count, "A").End(xlUp).Row
   For i = 2 To LastRow
   
   
    If Cells(i + 1, 1).Value <> Cells(i, 1).Value Then
           
           total = total + Cells(i, 7).Value
           
           If total = 0 Then
               
               Range("I" & 2 + SUKI).Value = Cells(i, 1).Value
               Range("J" & 2 + SUKI).Value = 0
               Range("K" & 2 + SUKI).Value = "%" & 0
               Range("L" & 2 + SUKI).Value = 0
            Else
             
              If Cells(start, 3) = 0 Then
               For find_number = start To i
                       If Cells(find_number, 3).Value <> 0 Then
                           start = find_number
                           Exit For
                       End If
                Next find_number
              End If
               
         
            YearlyChange = (Cells(i, 6) - Cells(start, 3))
            PerChange = YearlyChange / Cells(start, 3)
            
            start = i + 1
            Range("I" & 2 + SUKI).Value = Cells(i, 1).Value
            Range("J" & 2 + SUKI).Value = YearlyChange
            Range("J" & 2 + SUKI).NumberFormat = "0.00"
            Range("K" & 2 + SUKI).Value = PerChange
            Range("K" & 2 + SUKI).NumberFormat = "0.00%"
            Range("L" & 2 + SUKI).Value = total
            
                
                If (YearlyChange > 0) Then
                Range("J" & 2 + SUKI).Interior.ColorIndex = 4
                
                ElseIf (YearlyChange <= 0) Then
                Range("J" & 2 + SUKI).Interior.ColorIndex = 3
                
                End If
                
               
                If (PerChange > 0) Then
                Range("K" & 2 + SUKI).Interior.ColorIndex = 4
                
                ElseIf (PerChange <= 0) Then
                Range("K" & 2 + SUKI).Interior.ColorIndex = 3
                
                End If
               
               
            End If
                         
           
           total = 0
           YearlyChange = 0
           SUKI = SUKI + 1
           days = 0
           
       Else
           total = total + Cells(i, 7).Value
    End If
    
          
    Next i
     
     
  
    LastRow = Cells(Rows.Count, "I").End(xlUp).Row
    GreatestIncrease = 0
    GreatestDecrease = 0
    GreatestTotal = 0
    GreatestIncreaseTicker = ""
    GreatestDecreaseTicker = ""
    GreatestTotalTicker = ""
    
    For i = 2 To LastRow
    
    
        If Cells(i, 11).Value > GreatestIncrease Then
            GreatestIncreaseTicker = Cells(i, 9).Value
            GreatestIncrease = Cells(i, 11).Value
        End If
        
        If Cells(i, 11).Value < GreatestDecrease Then
            GreatestDecreaseTicker = Cells(i, 9).Value
            GreatestDecrease = Cells(i, 11).Value
        End If
        
        If Cells(i, 12).Value > GreatestTotal Then
            GreatestTotalTicker = Cells(i, 9).Value
            GreatestTotal = Cells(i, 12).Value
        End If
         
    Next
    
    Cells(2, 16).Value = GreatestIncreaseTicker
    Cells(2, 17).Value = GreatestIncrease
    Cells(2, 17).NumberFormat = "0.00%"
    Cells(3, 16).Value = GreatestDecreaseTicker
    Cells(3, 17).Value = GreatestDecrease
    Cells(3, 17).NumberFormat = "0.00%"
    Cells(4, 16).Value = GreatestTotalTicker
    Cells(4, 17).Value = GreatestTotal
    Cells(4, 17).NumberFormat = "#"

   
    Next ws

End Sub