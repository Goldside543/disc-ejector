#include <stdio.h>
#include <stdlib.h>

int main(void) {
    // Not really much to say, the code is self explanatory.
    system("eject D:");
    printf("If all went well, your disc has been ejected. If not, do the following and read the error message.")
    system("pause");
    // Below is a bit of code I'm trying to make open the error message file. The filename is temporary, and will be used until I get a proper exe file for it.
    errormessage();
    system("no-disc-error.exe")
    return 0;
}
