#include <bits/stdc++.h>
using namespace std;

class Student
{
public:
    int Id;
    char Name[100];
    char Section;
    float TotalMarks;
};

int main()
{
    int t;
    cin >> t;

    for (int i = 1; i <= t; i++)
    {
        Student a, b, c;
        cin >> a.Id >> a.Name >> a.Section >> a.TotalMarks;
        // cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;
        getchar();
        cin >> b.Id >> b.Name >> b.Section >> b.TotalMarks;
        // cout << b.Id << " " << b.Name << " " << b.Section << " " << b.TotalMarks << endl;
        getchar();
        cin >> c.Id >> c.Name >> c.Section >> c.TotalMarks;
        // cout << c.Id << " " << c.Name << " " << c.Section << " " << c.TotalMarks << endl;

        if (a.TotalMarks >= b.TotalMarks &&
            a.TotalMarks >= c.TotalMarks)
        {
            cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;
            // if (a.TotalMarks == b.TotalMarks  ||
            //     a.TotalMarks == c.TotalMarks)
            // {
            //     cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;

            // }else if(b.TotalMarks == c.TotalMarks)
            // {
            //     cout << b.Id << " " << b.Name << " " << b.Section << " " << b.TotalMarks << endl;
            // }
            // else
            // {
            //     cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;
            // }
        }
        else if (b.TotalMarks >= a.TotalMarks &&
                 b.TotalMarks >= c.TotalMarks)
        {
            if (b.TotalMarks == a.TotalMarks )
            {
                cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;

            }else if(b.TotalMarks == c.TotalMarks)
            {
                cout << b.Id << " " << b.Name << " " << b.Section << " " << b.TotalMarks << endl;
            }
            else
            {
                cout << b.Id << " " << b.Name << " " << b.Section << " " << b.TotalMarks << endl;
            }
        }
        else
        {
            if (c.TotalMarks == a.TotalMarks)
            {
                cout << a.Id << " " << a.Name << " " << a.Section << " " << a.TotalMarks << endl;

            }else if(c.TotalMarks == b.TotalMarks)
            {
                cout << b.Id << " " << b.Name << " " << b.Section << " " << b.TotalMarks << endl;
            }
            else
            {
                cout << c.Id << " " << c.Name << " " << c.Section << " " << c.TotalMarks << endl;
            }
        }
    }

    return 0;
}