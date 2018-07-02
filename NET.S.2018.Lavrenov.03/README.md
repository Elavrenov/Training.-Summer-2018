#TASK 1

����������� �������� FindNthRoot, 
����������� ��������� ������ n-�� ������� ( n ? N ) �� ������������� ����� � 
������� ������� � �������� ���������. ����������� ��������� ����� (NUnit � (���) MS Unit Test) ���
������������ ������. ��������� ���� �����:

[TestCase(1, 5, 0.0001,ExpectedResult =1)]
[TestCase(8, 3, 0.0001,ExpectedResult = 2)]
[TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]
[TestCase(0.04100625,4 , 0.0001, ExpectedResult =0.45)]
[TestCase(8, 3, 0.0001, ExpectedResult =2)]
[TestCase(0.0279936, 7, 0.0001, ExpectedResult =0.6)]
[TestCase(0.0081, 4, 0.1, ExpectedResult =0.3)]
[TestCase(-0.008, 3, 0.1, ExpectedResult =-0.2)]
[TestCase(0.004241979, 9, 0.00000001, ExpectedResult =0.545)]
[a = -0.01, n = 2, accurancy = 0.0001] <- ArgumentException
[a = 0.001, n = -2, accurancy = 0.0001] <- ArgumentException
[a = 0.01, n = 2, accurancy = -1] <- ArgumentException	...
��������������� ������ ��� ��������� ������ �������� ����������.

MethodName_Number_Degree_Precision_ArgumentOutOfRangeException
(double number, int degree, double precision, double expected) => Assert.Throws(() => ClassName.MethodName(number, degree, precision));

#TASK 5

����������� ����� FindNextBiggerNumber, ������� ��������� ������������� ����� ����� � ���������� ���������
���������� �����, ��������� �� ���� ��������� �����, � null (��� -1), ���� ������ ����� �� ����������.
����������� ��������� ����� (NUnit ��� MS Unit Test) ��� ������������ ������. ��������� ����-�����
[TestCase(12, ExpectedResult = 21)]
[TestCase(513, ExpectedResult = 531)]
[TestCase(2017, ExpectedResult = 2071)]
[TestCase(414, ExpectedResult = 441)]
[TestCase(144, ExpectedResult = 414)]
[TestCase(1234321, ExpectedResult = 1241233)]
[TestCase(1234126, ExpectedResult = 1234162)]
[TestCase(3456432, ExpectedResult = 3462345)]
[TestCase(10, ExpectedResult = -1)]
[TestCase(20, ExpectedResult = -1)]
�������� � ������ FindNextBiggerNumber ����������� ������� ����� ���������� ��������� �����,
���������� ��������� �������� �����������. ����������� ��������� ����� (NUnit ��� MS Unit Test) ��� ������������ ������.

#TASK 2

����������� �����, ����������� ��������� ���������� ��� �� ��������� ������� ��� ����, ���� � �.�. ����� �����
(http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ).
������ ������ ������ ���������� ��� ������ ������������� �������������� ����������� ����������� �������� �������, �����������
��� ���������� �������. �������� � �������������� ������ ������, ����������� �������� ������ (�������� �������� �������) ��� 
������� ��� ����, ���� � �.�. ����� ����� (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, 
https://habrahabr.ru/post/205106/ ), � ����� ������, ��������������� �������������� �����������
����������� �������� �������, ����������� ��� ���������� �������.
����������� ��������� ����������� ���������� �������, ������������ ����� ���������� ���. ����������� ��������� �����.