# LatviaMap - Latvian Settlements and Extreme Points Viewer

This project is a web application that allows users to view the most remote settlements of Latvia as well as search for Latvian settlements or cities. The application is built using ASP.NET Core MVC (C#) and Leaflet.js for interactive map rendering.

## Features

- **Extreme Points Display**: Shows four settlements that are the northernmost, southernmost, easternmost, and westernmost points of Latvia.
- **Settlement Search**: Provides a search bar with autocomplete functionality for users to search for Latvian settlements and display them on the map.
- **Responsive Design**: The map adapts to the full screen, taking up the space from the header to the bottom of the page, providing an optimal viewing experience on various screen sizes.
- **Dynamic Location Display**: Clicking on a settlement from the search dropdown pins its location on the map and provides detailed information about its latitude and longitude.

## Technologies

- **ASP.NET Core MVC**: Backend framework used to manage data, handle user requests, and serve pages.
- **Leaflet.js**: JavaScript library for rendering interactive maps.
- **CsvHelper**: Library used to parse CSV data from a dataset.
- **JavaScript (Fetch API)**: Used to handle AJAX requests for the search functionality.
- **HTML/CSS**: For layout and styling.

## Instructions

1.  **Clone the repository**:

    ```bash
    git clone https://github.com/JanisJIvdris/LatviaMap.git
    ```

2.  **Navigate to the project directory**:

    ```bash
    cd LatviaMap
    ```

3.  **Install dependencies** (if necessary):

    The project dependencies are managed via NuGet. Ensure all required NuGet packages are installed by running:

    ```bash
    dotnet restore
    ```

4.  **Run the application**:

    ```bash
    dotnet run
    ```

5.  **Access the application**:
   
    Open your browser and navigate to:

    ```
    http://localhost:5122
    ```

## Running the Application

1. **Explore the Map**: 
   - The map initially displays the four most remote points of Latvia.
   - You can click the **"Show Extreme Points"** button to display them again if needed.

2. **Search Settlements**:
   - Use the search bar at the top of the page to search for a settlement or city.
   - The autocomplete dropdown will show matching results as you type. Select a result to pin its location on the map.

3. **Pin a Location**:
   - Clicking on a settlement from the autocomplete dropdown will zoom the map to that settlement and display a marker with detailed information, including its name, latitude, and longitude.

## Notes

- The data for the Latvian settlements is fetched from the Latvian open data portal. The CSV file is automatically downloaded and extracted on the first run.
- The application design follows a minimalistic approach, with a focus on map interactivity and ease of use.

## Potential Improvements

- Implement user authentication to save favorite settlements or custom maps.
- Add filtering options based on settlement types, such as cities, towns, or villages.
- Enhance performance for larger datasets by implementing lazy loading or pagination for search results.
- Improve the design of the autocomplete dropdown for a more polished user experience.

## Personal Comments

This project was designed to be simple, functional, and user-friendly. The main focus was on utilizing government data and interactive mapping to showcase the most extreme points in Latvia and provide a quick, accessible way to search for and locate any settlement. The clean design ensures that the user’s focus remains on the map itself, imitating a natural and interactive experience.
