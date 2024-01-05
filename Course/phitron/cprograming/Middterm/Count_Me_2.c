/*
You will be given a string S as input contains only small English alphabets.
You need to tell the number of consonants in it. The string will not contain any spaces.

Note: Vowels are a,e,i,o and u. The rest are called consonants.

Input Format

Input will contain a string S.
Constraints

1 <= |S| <= 100000 ; Here |S| means the length of string S.
Output Format

Output the number of consonants.
*/

#include <stdio.h>
int main()
{
    char ch[100001];
    int count;

    for (int i = 0; i < 100000; i++)
    {
        scanf("%c", &ch[i]);
    }

    for (int i = 0; i < 100000; i++)
    {
        if(ch[i] == '\0')
        {
            break;
        }else if(ch[i] != 'a' &&
          ch[i] != 'e' &&
          ch[i] != 'i' &&
          ch[i] != 'o' &&
          ch[i] != 'u')
          {
            
            count++;
          }
    }
    

    printf("%d", count);
    return 0;
}
