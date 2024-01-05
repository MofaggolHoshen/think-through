#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int main()
{
    int n;
    scanf("%d", &n);
    int lines = n + 10;
    int TopTreeLine = (lines / 2) + 1;
    int totalLines = TopTreeLine + 5;
    int desh = TopTreeLine - 1;
    int star = 1;
    for (int i = 1; i <= totalLines; i++)
    {
        if (TopTreeLine >= i)
        {
            for (int j = 1; j <= desh; j++)
            {
                printf(" ");
            }

            for (int k = 1; k <= star; k++)
            {
                printf("*");
            }

            printf("\n");

            star += 2;
            desh -= 1;
        }else{
            for (int j = 1; j < 6; j++)
            {
                printf(" ");
            }

            for (int k = 1; k <= n; k++)
            {
                printf("*");
            }

            printf("\n");
        }
    }

    return 0;
}