Module ScriptsLib

    Public ApplyFinders As New List(Of String)

    Public Function ScriptParseFromContent(ByVal ScriptName As String, ByVal ScriptContent As String, ByVal Arguments As String, ByVal ArgumentTypes As String, ByVal IsPreview As Boolean, ByVal IsLocal As Boolean, ByVal IsC As Boolean) As String
        Dim FinalString As String = String.Empty
        If Not IsLocal Then
            FinalString = "int " + ScriptName + "("
            Dim ArgumentString As String = String.Empty
            Dim CommaCount As Byte = HowManyChar(Arguments, ",")
            If Arguments.Length > 0 Then
                For i As Byte = 0 To CommaCount
                    Dim ArgumentType As String = GenerateCType(iGet(ArgumentTypes, i, ","))
                    Dim ArgumentName As String = iGet(Arguments, i, ",")
                    ArgumentString += ArgumentType + " "
                    If ArgumentType = "char" Then ArgumentString += "*"
                    ArgumentString += ArgumentName
                    ArgumentString += ", "
                Next
                ArgumentString = ArgumentString.Substring(0, ArgumentString.Length - 2)
                FinalString += ArgumentString + ") {" + vbcrlf
            Else
                FinalString += "void) {" + vbcrlf
            End If
        End If
        If IsC Then
            For Each P As String In StringToLines(ScriptContent)
                If P.Length = 0 Then Continue For
                FinalString += MakeSpaces(2) + P + vbcrlf
            Next
            FinalString += "  return 0;" + vbcrlf
            FinalString += "}"
            Return FinalString
        End If
        Dim IndentChange As Byte = 0
        Dim CurrentIndent As Byte = If(IsLocal, 0, 1)
        Dim StringVariables As New List(Of String)
        For Each X As String In StringToLines(ScriptContent)
            If X.Length = 0 Then Continue For
            X = X.Replace(ControlChars.Tab, " ")
            IndentChange = 0
            For i As Byte = 0 To 200
                If Not X(0).ToString = " " Then Exit For
                X = X.Substring(1)
            Next
            While X.EndsWith(" ")
                X = X.Substring(0, X.Length - 1)
            End While
            Dim L As String = X.ToLower()
            Dim Output As String = String.Empty
            Dim TS As String = String.Empty
            If IsLocal Then
                For Each P As String In ApplyFinders
                    Dim NoBrackets As String = P.Substring(1)
                    NoBrackets = NoBrackets.Substring(0, NoBrackets.Length - 1)
                    X = X.Replace(P, "Instances[DAppliesTo]." + NoBrackets)
                Next
                X = X.Replace("[Me]", "DAppliesTo")
            End If
            If L.StartsWith("dim ") Then
                'If IsLocal Then Continue For
                X = X.Substring(4)
                L = L.Substring(4)
                If L.Contains(" as ") Then
                    Dim VariableName As String = X.Substring(0, L.IndexOf(" as "))
                    'MsgError("name is """ + VariableName + """")
                    Dim VariableType As String = X.Substring(L.IndexOf(" as ") + 4)
                    'MsgError("type is """ + VariableType + """")
                    Dim LVariableType As String = L.Substring(L.IndexOf(" as ") + 4)
                    'MsgError("lo type is """ + VariableType + """")
                    If VariableType.Contains(" = ") Then
                        VariableType = VariableType.Substring(0, VariableType.LastIndexOf(" = "))
                        LVariableType = LVariableType.Substring(0, LVariableType.LastIndexOf(" = "))
                    End If
                    Dim CVariableType As String = GenerateCType(LVariableType)
                    'MsgError("c var type is " + CVariableType)
                    'If CVariableType = "pie" Then CVariableType = VariableType
                    Dim VariableValue As String = String.Empty
                    If X.Contains(VariableType + " = ") Then
                        VariableValue = X.Substring(X.LastIndexOf(" = ") + 3)
                        If LVariableType = "boolean" Then
                            If VariableValue.ToLower = "yes" Then VariableValue = "true"
                            If VariableValue.ToLower = "no" Then VariableValue = "false"
                        End If
                    End If
                    TS = CVariableType + " " + VariableName
                    If LVariableType = "string" Then TS += "[128]"
                    If VariableValue.Length > 0 And Not VariableType = "string" Then
                        TS += " = "
                        TS += VariableValue
                    End If
                    TS += ";"
                    If LVariableType = "string" Then
                        StringVariables.Add(VariableName)
                        If VariableValue.Length = 0 Then
                            TS += " strcpy(" + VariableName + ", """");"
                        Else
                            TS += " strcpy(" + VariableName + ", " + VariableValue + ");"
                        End If
                    End If
                    Output = TS
                Else
                    TS = "int " + X + ";"
                    Output = TS
                End If
            ElseIf X.StartsWith("'") Then
                Output = "// " + X.Substring(1)
            ElseIf L.StartsWith("rem ") Then
                Output = "// " + X.Substring(4)
            ElseIf L.StartsWith("return ") Then
                Output = "return " + X.Substring(("return ").Length) + ";"
            ElseIf L.StartsWith("for ") Then
                X = X.Substring(4)
                L = L.Substring(4)
                Dim VariableName As String = X.Substring(0, X.IndexOf(" = "))
                Dim LVariableName As String = L.Substring(0, L.IndexOf(" = "))
                Dim DFrom As String = X.Substring(VariableName.Length + 3)
                Dim LDFrom As String = L.Substring(LVariableName.Length + 3)
                DFrom = DFrom.Substring(0, LDFrom.IndexOf(" to "))
                Dim DTo As String = X.Substring(L.LastIndexOf(" to ") + 4)
                'Dim LDTo As String = L.Substring(L.LastIndexOf(" to ") + 4)
                Output = "for (" + VariableName + " = " + DFrom + "; " + VariableName
                Output += " < (" + DTo + " + 1); " + VariableName + "++) {"
                IndentChange = 2
            ElseIf L = "next" Or L.StartsWith("next ") Then
                Output = "}"
                IndentChange = 1
            ElseIf L.StartsWith("if ") Then
                X = X.Substring(3)
                L = L.Substring(3)
                Dim IsString As Boolean = False
                Dim Value As String = X
                If Value.Contains(" = ") Then
                    Value = Value.Substring(Value.IndexOf(" = ") + 3)
                    If Value.StartsWith("""") And Value.EndsWith("""") Then IsString = True
                End If
                Dim DName As String = X
                If DName.Contains(" = ") Then
                    DName = DName.Substring(0, DName.IndexOf(" = "))
                    If StringVariables.Contains(DName) Then IsString = True
                End If
                If Not IsString Then
                    X = X.Replace(" = ", " == ")
                    X = X.Replace(" And ", " && ")
                    X = X.Replace(" Or ", " || ")
                End If
                Dim Condition As String = X
                L = Condition.ToLower
                If IsString Then
                    If L.StartsWith("not ") Then
                        X = X.Substring(4)
                        L = L.Substring(4)
                        Condition = "!(strcmp(" + DName + ", " + Value + ") == 0)"
                    Else
                        Condition = "strcmp(" + DName + ", " + Value + ") == 0"
                    End If
                Else
                    If L.StartsWith("not ") Then
                        Condition = Condition.Substring(4)
                        Output = "if (!(" + Condition + ")) {"
                    Else
                        Output = "if (" + Condition + ") {"
                    End If
                End If
                IndentChange = 2
            ElseIf L = "else" Then
                Output = "} else {"
            ElseIf L = "end if" Then
                Output = "}"
                IndentChange = 1
                'ElseIf X.StartsWith("|") Then
                '    X = X.Substring(1)
                '    If X.StartsWith(" ") Then
                '        For i As Byte = 0 To 100
                '            If Not X.Substring(0, 1) = " " Then Exit For
                '            X = X.Substring(1)
                '        Next
                '    End If
                '    Output = X
            ElseIf X.Contains(" = ") Then
                If Not X.Substring(X.IndexOf(" "), 3) = " = " Then Continue For
                Dim VariableName As String = X.Substring(0, X.IndexOf(" "))
                Dim VariableValue As String = X.Substring(X.IndexOf(" = ") + 3)
                If VariableValue.ToLower = "true" Or VariableValue.ToLower = "false" Then VariableValue = VariableValue.ToLower
                Dim IsString As Boolean = False
                If VariableValue.StartsWith("""") And VariableValue.EndsWith("""") Then IsString = True
                If StringVariables.Contains(VariableName) Then IsString = True
                If IsString Then
                    If VariableName.Contains(".") Then
                        Output = VariableName + " = """"; strcpy(" + VariableName + ", " + VariableValue + ");"
                    Else
                        Output = " strcpy(" + VariableName + ", " + VariableValue + ");"
                    End If
                Else
                    Output = VariableName + " = " + VariableValue + ";"
                End If
            End If
            If IndentChange = 1 Then
                If CurrentIndent > 1 Then
                    For i = 0 To CurrentIndent - 2
                        FinalString += "  "
                    Next
                End If
                If CurrentIndent > 0 Then
                    CurrentIndent -= 1
                End If
            Else
                If CurrentIndent > 0 Then
                    For i = 0 To CurrentIndent - 1
                        FinalString += "  "
                    Next
                End If
            End If
            If Output.Length = 0 Then
                If X.EndsWith(";") Then
                    Output = X
                Else
                    Output = X + ";"
                End If
            End If
            FinalString += Output + vbcrlf
            If IndentChange = 2 Then CurrentIndent += 1
        Next
        If Not IsLocal Then FinalString += "  return 0;" + vbcrlf
        If Not IsLocal Then FinalString += "}"
        'If FinalString.Length > 0 Then
        '    FinalString = FinalString.Substring(0, FinalString.Length - 2)
        'End If
        'MsgError("""" + FinalString + """")5
        Return FinalString
    End Function

    Public Function ScriptParse(ByVal ScriptName As String, ByVal IsC As Boolean) As String
        Dim ArgumentsString As String = String.Empty
        Dim ArgumentTypesString As String = String.Empty
        For Each X As String In GetXDSFilter("SCRIPTARG " + ScriptName + ",")
            X = X.Substring(10)
            ArgumentsString += iGet(X, 1, ",") + ","
            ArgumentTypesString += iGet(X, 2, ",") + ","
        Next
        If ArgumentsString.Length > 0 Then
            ArgumentsString = ArgumentsString.Substring(0, ArgumentsString.Length - 1)
            ArgumentTypesString = ArgumentTypesString.Substring(0, ArgumentTypesString.Length - 1)
        End If
        Return ScriptParseFromContent(ScriptName, PathToString(SessionPath + "Scripts\" + ScriptName + ".dbas"), ArgumentsString, ArgumentTypesString, False, False, IsC)
    End Function

    Function ActionTypeToString(ByVal ActionType As Byte) As String
        If ActionType = 0 Then Return "Objects"
        If ActionType = 1 Then Return "Media"
        If ActionType = 2 Then Return "Control"
        If ActionType = 3 Then Return "Display"
        If ActionType = 4 Then Return "Score"
        If ActionType = 5 Then Return "Advanced"
        Return "Extra"
    End Function

    Function ActionStringToType(ByVal ActionString) As Byte
        If ActionString = "Objects" Then Return 0
        If ActionString = "Media" Then Return 1
        If ActionString = "Control" Then Return 2
        If ActionString = "Display" Then Return 3
        If ActionString = "Score" Then Return 4
        If ActionString = "Advanced" Then Return 5
        Return 5
    End Function

    Function ArgumentTypeToString(ByVal Type As Byte) As String
        If Type = 1 Then Return "Screen"
        If Type = 2 Then Return "TrueFalse"
        If Type = 3 Then Return "Variable"
        If Type = 4 Then Return "Object"
        If Type = 5 Then Return "Background"
        If Type = 6 Then Return "Sound"
        If Type = 7 Then Return "Room"
        If Type = 9 Then Return "Script"
        If Type = 10 Then Return "Comparative"
        If Type = 11 Then Return "Font"
        If Type = 12 Then Return "Unrestrictive"
        If Type = 13 Then Return "Sprite"
        If Type = 14 Then Return "CScript"
        Return "Undefined"
    End Function

    Function ArgumentStringToType(ByVal Type As String) As Byte
        If Type = "Screen" Then Return 1
        If Type = "TrueFalse" Then Return 2
        If Type = "Variable" Then Return 3
        If Type = "Object" Then Return 4
        If Type = "Background" Then Return 5
        If Type = "Sound" Then Return 6
        If Type = "Room" Then Return 7
        If Type = "Script" Then Return 9
        If Type = "Comparative" Then Return 10
        If Type = "Font" Then Return 11
        If Type = "Unrestrictive" Then Return 12
        If Type = "Sprite" Then Return 13
        If Type = "CScript" Then Return 14
        If Type = "Array" Then Return 15
        If Type = "Structure" Then Return 16
        Return 0
    End Function

    Function MainClassTypeToString(ByVal TheMainClass As Byte) As String
        If TheMainClass = 0 Then Return "Unused"
        If TheMainClass = 1 Then Return "Create"
        If TheMainClass = 2 Then Return "Button Press"
        If TheMainClass = 3 Then Return "Button Held"
        If TheMainClass = 4 Then Return "Button Released"
        If TheMainClass = 5 Then Return "Touch"
        If TheMainClass = 6 Then Return "Collision"
        If TheMainClass = 7 Then Return "Step"
        If TheMainClass = 8 Then Return "Other"
        Return "Unused"
    End Function

    Function MainClassStringToType(ByVal TheMainClass As String) As Byte
        If TheMainClass = "Unused" Then Return 0
        If TheMainClass = "Create" Then Return 1
        If TheMainClass = "Button Press" Then Return 2
        If TheMainClass = "Button Held" Then Return 3
        If TheMainClass = "Button Released" Then Return 4
        If TheMainClass = "Touch" Then Return 5
        If TheMainClass = "Collision" Then Return 6
        If TheMainClass = "Step" Then Return 7
        If TheMainClass = "Other" Then Return 8
        Return 0
    End Function

    Public VariableTypes As New List(Of String)

    Function GenerateCType(ByVal HumanVT As String) As String
        Select Case HumanVT.ToLower
            Case "integer"
                Return "int"
            Case "boolean"
                Return "bool"
            Case "float"
                Return "float"
            Case "unsigned byte"
                Return "u8"
            Case "signed byte"
                Return "s8"
            Case "string"
                Return "char"
        End Select
        Return HumanVT
    End Function

    'Function ScriptArgumentStringToType(ByVal Type As String) As Byte
    '    If Type = "Integer" Then Return 0
    '    If Type = "Boolean" Then Return 1
    '    If Type = "Float" Then Return 2
    '    If Type = "Signed Byte" Then Return 3
    '    If Type = "Unsigned Byte" Then Return 4
    '    If Type = "String" Then Return 5
    '    Return 0
    'End Function

    Function StringToComparative(ByVal InputString As String) As String
        If InputString = "Less than" Then Return "<"
        If InputString = "Greater than" Then Return ">"
        If InputString = "Equal to" Then Return "=="
        If InputString = "Less than or Equal to" Then Return "<="
        If InputString = "Greater than or Equal to" Then Return ">="
        If InputString = "Not Equal to" Then Return "!="
        Return "=="
    End Function

    Function ComparativeToString(ByVal InputString As String) As String
        If InputString = "<" Then Return "Less than"
        If InputString = ">" Then Return "Greater than"
        If InputString = "==" Then Return "Equal to"
        If InputString = "<=" Then Return "Less than or Equal to"
        If InputString = ">=" Then Return "Greater than or Equal to"
        If InputString = "!=" Then Return "Not equal to"
        Return "Equal to"
    End Function

End Module
