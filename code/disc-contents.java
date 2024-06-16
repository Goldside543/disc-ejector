import java.io.File;

public class ListDriveContents {
    public static void main(String[] args) {
        // Define the directory path for the D: drive
        File drive = new File("D:/");

        // Check if the drive exists and is a directory
        if (drive.exists() && drive.isDirectory()) {
            // Get the list of files and directories in the drive
            File[] contents = drive.listFiles();

            if (contents != null) {
                // Loop through the contents and print the names
                for (File file : contents) {
                    if (file.isDirectory()) {
                        System.out.println("[DIR] " + file.getName());
                    } else {
                        System.out.println("[FILE] " + file.getName());
                    }
                }
            } else {
                System.out.println("The D: drive is empty or could not be accessed.");
            }
        } else {
            System.out.println("The D: drive does not exist or is not a directory.");
        }
    }
}
