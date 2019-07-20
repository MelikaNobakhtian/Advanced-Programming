using System.Collections.Generic;

namespace P1
{
    public class Equation
    {
        private string[] MyEquations { get; }
        public List<char> Variables { get; set; }
        public SquareMatrix<double> Coefficients { get; set; }
        public Matrix<double> Numbers { get; set; }
        public Matrix<double> MyResult { get; set; }

        public Equation(string[] equations)
        {
            MyEquations = equations;
            ParseEquation();
        }

        public void ParseEquation()
        {
            Numbers = new Matrix<double>(MyEquations.Length, 1);
            Variables = new List<char>(MyEquations.Length);
            GetVariables(MyEquations[0]);
            MultipleMatrix();
            for (var i = 0; i < MyEquations.Length; i++)
            {
                var parts = MyEquations[i].Split('=');
                Numbers[i, 0] = double.Parse(parts[parts.Length - 1]);
            }
        }

        public void GetVariables(string parts)
        {
            foreach (var c in parts)
                if (char.IsLetter(c) && !Variables.Contains(c))
                    Variables.Add(c);
        }

        public void MultipleMatrix()
        {
            Coefficients = new SquareMatrix<double>(MyEquations.Length);
            string coefficient = null;

            var j = 0;
            foreach (var v in Variables)
            {
                for (var i = 0; i < MyEquations.Length; i++)
                {
                    var index = MyEquations[i].IndexOf(v);
                    if (index == 0)
                    {
                        Coefficients[i, j] = 1;
                        continue;
                    }

                    if (index == 1)
                    {
                        Coefficients[i, j] = double.Parse(MyEquations[i][0].ToString());
                        continue;
                    }


                    for (var k = index - 1; k >= 0; k--)
                        if (!char.IsLetter(MyEquations[i][k]))
                        {
                            coefficient = MyEquations[i][k] + coefficient;
                        }
                        else
                        {
                            if (coefficient == "+" || coefficient == "-")
                                coefficient += "1";
                            Coefficients[i, j] = double.Parse(coefficient);
                            coefficient = null;
                            break;
                        }
                }

                j++;
            }
        }

        public Matrix<double> SetRelations(int row1, int row2)
        {
            var relations = new Matrix<double>(1, MyEquations.Length + 1);
            for (var j = 0; j < MyEquations.Length; j++)
                relations[0, j] = Coefficients[row1, j] / Coefficients[row2, j];
            relations[0, MyEquations.Length] = Numbers[row1, 0] / Numbers[row2, 0];

            return relations;
        }

        public string HasSameRelation(Matrix<double> Relations)
        {
            var relation = Relations[0, 0];
            string result = null;
            for (var i = 1; i < Relations.ColumnCount; i++)
                if (relation == Relations[0, i])
                {
                    if (i == Relations.ColumnCount - 2)
                        result = "No Solution";
                    else if (i == Relations.ColumnCount - 1)
                        result = "No Unique Solution";
                }
                else
                {
                    break;
                }

            return result;
        }

        public string Results()
        {
            string answers = null;
            Matrix<double> result;
            string relationresult = null;
            if (Coefficients.Determinant(Coefficients) == 0)
            {
                for (var i = 0; i < MyEquations.Length; i++)
                    for (var j = i + 1; j < MyEquations.Length; j++)
                    {
                        result = SetRelations(i, j);
                        if (HasSameRelation(result) != null)
                        {
                            if (HasSameRelation(result) == "No Solution")
                                return HasSameRelation(result);
                            if (HasSameRelation(result) == "No Unique Solution")
                                relationresult = HasSameRelation(result);
                        }
                    }

                if (relationresult == "No Unique Solution")
                    return relationresult;
            }

            MyResult = new Matrix<double>(MyEquations.Length, 1);
            MyResult = Coefficients.InverseMatrix() * Numbers;
            for (var i = 0; i < MyResult.RowCount; i++)
                if (i != MyResult.RowCount - 1)
                    answers += $"{Variables[i]}={MyResult[i, 0]},";
                else
                    answers += $"{Variables[i]}={MyResult[i, 0]}";

            return answers;
        }
    }
}