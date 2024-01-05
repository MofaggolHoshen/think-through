#include <bits/stdc++.h>
using namespace std;

int main()
{

    char ar[100000];
    
    while (cin.getline(ar,100000))
    {
        int letter[26] = {0};
        int len = strlen(ar);
        
        for (int i = 0; i < len; i++)
        {
            if(ar[i]>= 'a' && ar[i] <='z')
            {
                int index = ar[i] - 'a';
                letter[index]++;
            }
        }

        for (int k = 0; k < 26; k++)
        {
            for (int z = 0; z < letter[k]; z++)
            {
                cout << (char)(k + 'a');
            }
        }
        
        cout << endl;
        
    }
}