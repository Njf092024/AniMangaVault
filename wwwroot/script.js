const apiUri = "/api/animemanga";

async function fetchAnimeMangaItems() 
{
    const response = await fetch(apiUri);
    const items = await response.json();

    const listContainer = document.getElementById("animeMangaList");
    listContainer.innerHTML = "";

    items.forEach(item =>
    {
        const listItem = document.createElement("li");
        listItem.textContent = '${item.id}: ${item.title} (${item.type}) - Rating: ${item.rating}';
        listContainer.appendChild(listItem);
        });
        {

            async function addAnimeMangaItem()
            {
                const title = document.getElementById("title").value;
                const type = document.getElementById("type").value;
                const description = document.getElementById("description").value;
                const rating = parseInt(document.getElementById("rating").value);

                const newItem = { title, type, description, rating };

                await fetch(apiUri, 
                    {
                        method: "POST",
                        headers: 
                        { 
                            "Content-Type": "application/json"
                         },
                         body: JSON.stringify(newItem)
                         });

                         fetchAnimeMangaItems();
            }

            document.addEventListener("DOMContentLoaded", fetchAnimeMangaItems);
        }}