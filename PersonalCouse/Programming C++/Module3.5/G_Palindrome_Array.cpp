#include <bits/stdc++.h>
using namespace std;

int main()
{
    int n;
    cin >> n;
    int ar[n];
    for (int i = 0; i < n; i++)
    {
        
        cin >> ar[i];
    }
    
    int palindom = 1;
    int i = 0;
    int j = n -1;
    
    while (1)
    {
        if(i == j)
        break;

        if(ar[i] != ar[j])
        {
            palindom = -1;
            //cout << ar[i] << "!=" << ar[j]<< endl;
            break;
        }

        i++;
        j--;
    }
    
    if(palindom == 1)
    {
        cout << "YES";
    }else{
        cout << "NO";
    }
}