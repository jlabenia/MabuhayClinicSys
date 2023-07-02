Module Others
    'Login
    Public loginUserid As Integer = Nothing
    Public loginUserType As String = Nothing
    Public loginUsername As String = Nothing
    Public logNo As Integer = Nothing
    '
    'Public userAction As String = Nothing '//For termination
    'Public userActvty As String = Nothing '//For termination
    'Public fullname As String = Nothing '//For review

    'Clinic personnel info
    Public c_personnel_id As Integer = Nothing
    Public cp_fname As String = Nothing
    Public cp_mname As String = Nothing
    Public cp_lname As String = Nothing
    Public cp_dobDay As Integer = Nothing
    Public cp_dobMonth As String = Nothing
    Public cp_dobYear As Integer = Nothing
    Public cp_Age As Integer = Nothing
    Public cp_gender As String = Nothing
    Public cp_contactno As String = Nothing
    Public cp_address As String = Nothing
    'Doctor information
    Public doctorID As Integer = Nothing
    Public licensedNo As String = Nothing
    Public doctorFname As String = Nothing
    Public doctorMname As String = Nothing
    Public doctorLname As String = Nothing
    Public doctorgender As String = Nothing
    Public doctoraddress As String = Nothing
    Public dr_contactNo As String = Nothing
    Public doctorAge As Integer = Nothing
    Public doctorBday As Integer = Nothing
    Public doctorMonth As String = Nothing
    Public doctorYear As Integer = Nothing
    Public specialization As String = Nothing
    'Admin information
    Public adminid As Integer = Nothing
    Public adminfirstname As String = Nothing
    Public adminMiddlename As String = Nothing
    Public adminLastname As String = Nothing
    Public adminAge As Integer = Nothing
    Public adminDOBday As Integer = Nothing
    Public adminDOBmonth As String = Nothing
    Public adminDOByear As Integer = Nothing
    Public admingender As String = Nothing
    Public adminAddress As String = Nothing
    Public admincontactnum As String = Nothing
    '
    Public amountDue As Decimal = Nothing
    Public customerName As String = Nothing
    '*********************************************************************************************
    '!COMMENT: PROPERTY
    Public _fname As String = Nothing
    Public _mname As String = Nothing
    Public _lname As String = Nothing
    Public _brgy As String = Nothing
    Public _municpalty As String = Nothing
    Public _province As String = Nothing
    '
    Public _barcode As String = ""
    Public _itemno As Integer = 0
    Public _itemName As String = ""
    Public _typeofitem As String = ""
    Public _UOM As String = ""
    Public _qty As Integer = 0
    Public _price As Decimal = 0
    Public _subtotal As Decimal = 0
    '!COMMENT: PUBLIC PROPERTY
    'FIRST NAME
    Public Property ProprtyFname() As String
        Get
            Return _fname
        End Get

        Set(ByVal value As String)
            _fname = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'MIDDLENAME
    Public Property ProprtyMname() As String
        Get
            Return _mname
        End Get

        Set(value As String)
            _mname = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'LASTNAME
    Public Property ProprtyLname() As String
        Get
            Return _lname
        End Get

        Set(value As String)
            _lname = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'BRGY
    Public Property ProprtyBrgy() As String
        Get
            Return _brgy
        End Get

        Set(value As String)
            _brgy = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'MUNICIPALITY
    Public Property ProprtyMunicipality() As String
        Get
            Return _municpalty
        End Get

        Set(value As String)
            _municpalty = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'PROVINCE
    Public Property ProprtyProvince() As String
        Get
            Return _province
        End Get

        Set(value As String)
            _province = StrConv(value, VbStrConv.ProperCase)
        End Set
    End Property
    'TXT BARCODE
    'END!
    '************************************************
    '!COMMENT: METHODS
    'Message box
    Sub msgbBoxShw()
        MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    End Sub
    'Clear clinic personnel variables
    Public Sub reset_cp_variables()
        c_personnel_id = Nothing
        cp_fname = Nothing
        cp_mname = Nothing
        cp_lname = Nothing
        cp_dobDay = Nothing
        cp_dobMonth = Nothing
        cp_dobYear = Nothing
        cp_Age = Nothing
        cp_gender = Nothing
        cp_contactno = Nothing
    End Sub '//green code
    'Clear doctor personnel variables
    Public Sub reset_doctor_variables()
        doctorID = Nothing
        licensedNo = Nothing
        doctorFname = Nothing
        doctorMname = Nothing
        doctorLname = Nothing
        doctorgender = Nothing
        doctoraddress = Nothing
        dr_contactNo = Nothing
        specialization = Nothing
        doctorAge = Nothing
        doctorBday = Nothing
        doctorMonth = Nothing
        doctorYear = Nothing
    End Sub '//green code
    'Clear global ordered items variables
    Public Sub glblorderItemVarreset()
        _barcode = ""
        _itemno = 0
        _itemName = ""
        _typeofitem = ""
        _UOM = ""
        _qty = 0
        _price = 0.0
        _subtotal = 0.0
        '
        _barcode = Nothing
        _itemno = Nothing
        _itemName = Nothing
        _typeofitem = Nothing
        _UOM = Nothing
        _qty = Nothing
        _price = Nothing
        _subtotal = Nothing

    End Sub
    'Clear login variables
    Public Sub reset_login_variables()
        loginUserid = Nothing
        loginUsername = Nothing
        loginUserType = Nothing
        logNo = Nothing
    End Sub
    '
    Public Sub reset_Adminvariables()
        adminid = Nothing
        adminfirstname = Nothing
        adminMiddlename = Nothing
        adminLastname = Nothing
        adminAge = Nothing
        adminDOBday = Nothing
        adminDOBmonth = Nothing
        adminDOByear = Nothing
        admingender = Nothing
        adminAddress = Nothing
        admincontactnum = Nothing
    End Sub
    'END!
    '************************************************
    '//New Class
    Public Class orderItems
        Public Property BARCODE As String
        Public Property ITEMNAME As String
        Public Property ITEMNO As Integer
        Public Property UOM As String
        Public Property TYPE As String
        Public Property QTY As Integer
        Public Property PRICE As Decimal
        Public Property SUBTOTAL As Decimal

        Public Sub clearOrderitemsProperty()
            BARCODE = Nothing
            ITEMNAME = Nothing
            ITEMNO = Nothing
            UOM = Nothing
            TYPE = Nothing
            QTY = Nothing
            PRICE = Nothing
            SUBTOTAL = Nothing
        End Sub
    End Class
End Module
