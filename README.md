<a id="readme-top"></a>

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">

<h3 align="center">Unity Steering Behaviours</h3>

  <p align="center">
    Simple Unity project with steering behaviours implemented in C#.
    <br />
    <br />
    <a href="https://github.com/iistarion/unity-steering">View Demo</a>
    &middot;
    <a href="https://github.com/iistarion/unity-steering/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    &middot;
    <a href="https://github.com/iistarion/unity-steering/issues/new?labels=enhancement&template=feature-request---.md">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot]

In this project, we have implemented several steering behaviours in Unity using C#, including:
- Seek
- Arrive
- Flee
- Pursue
- Evade

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

[![Unity][Unity]][Unity-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

- Clone (or download) the repo into your local machine.
- Open the project with Unity (6.0 LTS).
- Open the `Assets/Scenes/START_HERE.unity` scene and press "Play" on Unity.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Prerequisites

Unity 6.0 LTS installed on your computer.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/iistarion/unity-steering.git
   ```
2. Open the Project
   - Open Unity Hub and click on "Add" to add the cloned project.
   - Select the folder where you cloned the repo.
3. Open the "START_HERE" scene
   - In the Project window, navigate to `Assets/Scenes/`.
   - Double-click on `START_HERE.unity` to open the scene.
   - Press "Play" in Unity to start the project.
4. In order to edit a specific behaviour, you can open the corresponding *scene:
   - In the Project window, navigate to `Assets/Scenes/`.
   - Pick any behaviour scene you want to edit (e.g., `Seek.unity`, `Arrive.unity`, etc.) and drag and drop it into the Hierarchy window. This way we'll have both scenes open.


***Note:** The behaviour scenes are pretty plain and don't include a camera, so its better to open 2 scenes: the "START_HERE" one and the scene for the behaviour we want to edit. If we dont do that, the behaviour scenes will be missing camera and other components, which will make it difficult to see the behaviour in action.
<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

I use Trello for project management:
https://trello.com/b/SQqKHUWV/unity-projects

See the [open issues](https://github.com/iistarion/unity-steering/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

This repo is **stable** and not accepting pull requests.

- 🐞 Report bugs or broken samples → open an **Issue**.
- 💡 Propose enhancements or Unity-version updates → open an **Issue** (use the template).
- 🔀 Want to change code? Please **fork** the repo and maintain your fork.

Thanks for understanding!

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT license.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Carlos Yaque - https://www.carlos-yaque.com

Project Link: [https://github.com/iistarion/unity-steering](https://github.com/iistarion/unity-steering)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/iistarion/unity-steering.svg?style=for-the-badge
[contributors-url]: https://github.com/iistarion/unity-steering/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/iistarion/unity-steering.svg?style=for-the-badge
[forks-url]: https://github.com/iistarion/unity-steering/network/members
[stars-shield]: https://img.shields.io/github/stars/iistarion/unity-steering.svg?style=for-the-badge
[stars-url]: https://github.com/iistarion/unity-steering/stargazers
[issues-shield]: https://img.shields.io/github/issues/iistarion/unity-steering.svg?style=for-the-badge
[issues-url]: https://github.com/iistarion/unity-steering/issues
[license-shield]: https://img.shields.io/github/license/iistarion/unity-steering.svg?style=for-the-badge
[license-url]: https://github.com/iistarion/unity-steering/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/carlos-yaque-b8a97a9
[product-screenshot]: images/screenshot.png
[Unity]: https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white
[Unity-url]: https://unity.com/