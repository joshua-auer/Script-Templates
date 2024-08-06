# Script Templates

![Script-Templates Example](https://github.com/user-attachments/assets/08738993-7cf7-4e47-b763-b2bb80657cf7)

A collection of C# script templates that allow you to easily create various types of scripts from within the Unity editor. This package includes 4 templates:

- MonoBehaviour
- ScriptableObject
- Class
- Interface

## How To Install Templates

1. First you will need to import this package into your Unity project (see [Package Installation](#package-installation) below).
2. Once the package has been imported into your project, you will need to install the script templates. This can be done by navigating to the top menu and selecting `Tools->Script Templates->Install Script Templates`.

   ![Script-Templates Installation](https://github.com/user-attachments/assets/97bc994d-9842-4c47-8c44-b855b13880fc)

4. When the script templates have finished installing you will be prompted to restart the Unity editor. Although you don't have to restart the editor immediately, the script templates won't appear until you have restarted the editor.

> [!NOTE]
> The script templates only need to be installed once per Unity editor version. Once the script templates have been installed, they will be available across any project that uses the same version. Whenever you update to a new Unity editor version, you will have to reinstall the script templates for that new editor version.

## Package Installation

- ### Option 1: Package Manager (recommended)
    
    1. Open the Package Manager from within Unity by going to `Window->Package Manager`
    2. Click the `+` icon in the top left corner of the Package Manager window and select `Add package from git URL...`
    3. Copy paste the following URL into the text box and click import:

        ```
        https://github.com/joshua-auer/Script-Templates.git
        ```

- ### Option 2: Add To Manifest

    Locate your project's `manifest.json` file and add the following line:

    ```json
    "com.joshua-auer.script-templates": "https://github.com/joshua-auer/Script-Templates.git"
    ```
