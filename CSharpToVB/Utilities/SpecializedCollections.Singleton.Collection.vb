﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System
Imports System.Collections
Imports System.Collections.Generic

Partial Module SpecializedCollections
    Partial Friend NotInheritable Class Singleton
        Friend NotInheritable Class List(Of T)
            Implements IList(Of T), IReadOnlyCollection(Of T)

            Private ReadOnly _loneValue As T

            Public Sub New(value As T)
                Me._loneValue = value
            End Sub

            Public Sub Add(item As T) Implements ICollection(Of T).Add
                Throw New NotSupportedException()
            End Sub

            Public Sub Clear() Implements ICollection(Of T).Clear
                Throw New NotSupportedException()
            End Sub

            Public Function Contains(item As T) As Boolean Implements ICollection(Of T).Contains
                Return EqualityComparer(Of T).Default.Equals(Me._loneValue, item)
            End Function

            Public Sub CopyTo(array() As T, arrayIndex As Integer) Implements ICollection(Of T).CopyTo
                array(arrayIndex) = Me._loneValue
            End Sub

            Public ReadOnly Property Count() As Integer Implements ICollection(Of T).Count, IReadOnlyCollection(Of T).Count
                Get
                    Return 1
                End Get
            End Property

            Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of T).IsReadOnly
                Get
                    Return True
                End Get
            End Property

            Public Function Remove(item As T) As Boolean Implements ICollection(Of T).Remove
                Throw New NotSupportedException()
            End Function

            Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
                Return New Enumerator(Of T)(Me._loneValue)
            End Function

            Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
                Return Me.GetEnumerator()
            End Function

            Default Public Property Item(index As Integer) As T Implements IList(Of T).Item
                Get
                    If index <> 0 Then
                        Throw New IndexOutOfRangeException()
                    End If

                    Return Me._loneValue
                End Get

                Set(value As T)
                    Throw New NotSupportedException()
                End Set
            End Property

            Public Function IndexOf(item As T) As Integer Implements IList(Of T).IndexOf
                If Equals(Me._loneValue, item) Then
                    Return 0
                End If

                Return -1
            End Function

            Public Sub Insert(index As Integer, item As T) Implements IList(Of T).Insert
                Throw New NotSupportedException()
            End Sub

            Public Sub RemoveAt(index As Integer) Implements IList(Of T).RemoveAt
                Throw New NotSupportedException()
            End Sub
        End Class
    End Class
End Module
