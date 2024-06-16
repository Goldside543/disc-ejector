#include <iostream>
#include <windows.h>
#include <ioapiset.h>

int errormessage() {
bool IsDiscInDrive(const wchar_t driveLetter) {
    // Construct the drive path (e.g., "D:")
    wchar_t drivePath[] = { driveLetter, L':', L'\\', L'\0' };

    // Open the drive
    HANDLE hDrive = CreateFile(drivePath, 0, FILE_SHARE_READ | FILE_SHARE_WRITE, nullptr, OPEN_EXISTING, 0, nullptr);
    if (hDrive == INVALID_HANDLE_VALUE) {
        std::cerr << "Error opening drive " << drivePath << std::endl;
        return false;
    }

    // Check if the drive is ready (has a disc)
    DWORD bytesReturned;
    STORAGE_PROPERTY_QUERY query{};
    query.QueryType = PropertyStandardQuery;

    DWORD mediaContent = 0;
    if (DeviceIoControl(hDrive, IOCTL_STORAGE_CHECK_VERIFY, &query, sizeof(query), &mediaContent, sizeof(mediaContent), &bytesReturned, nullptr)) {
        // Media is present
        CloseHandle(hDrive);
        return true;
    }
    else {
        // No media or error
        CloseHandle(hDrive);
        return false;
    }
}

int main() {
    wchar_t driveLetter = L'D';
    if (IsDiscInDrive(driveLetter)) {
        std::cout << "Disc is present in drive " << driveLetter << std::endl;
    }
    else {
        std::cerr << "No disc found in drive " << driveLetter << std::endl;
    }

    system("pause");

    return 0;
}

}
