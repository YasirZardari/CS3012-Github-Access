# CS3012-Github-Access and Visualisation

The purpose of this task was to retrieve information regarding a Github user using the Github API and to display the data using visually.
The data I choose to represent was the number of repositories a user has based on its language. I feel this data can be important as it can help highlight where an individual or team is suited in terms of language in the software engineering process. The data is displayed using a bar chart and a pie chart.
The user chosen in this example is the Github user "facebook" , https://github.com/facebook.

The Github API C# program goes over the repositories for the specified user, counting an instance of a language of the repository. After this, it creates a csv file where the data is stored.
A bar chart is created using the .csv file. The template of the bar chart uses the d3.js library and is found here: https://bl.ocks.org/d3noob/bdf28027e0ce70bd132edc64f1dd7ea4

A pie chart is also provided. The pie chart was created using the d3pie generator which can be found here: http://d3pie.org/#generator-start-pie1

The visualisations can be found on my website here: https://yasirzardari.github.io/

**Attention**  

The github access assignment which displays info regarding the logged in user is found in the C# program in this repository but is currently commented out for convenient sake.

