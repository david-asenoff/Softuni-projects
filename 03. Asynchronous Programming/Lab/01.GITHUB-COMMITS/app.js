async function loadCommits() {

    const username = document.getElementById('username');
    const repo = document.getElementById('repo');
    const commitsUl = document.getElementById('commits');
    const url = `https://api.github.com/repos/${username.value}/${repo.value}/commits`;

    commitsUl.innerHTML = '';

    try {
        const response = await fetch(url);

        if (response.status == 200) {

            const reposJson = await response.json();

            Object.entries(reposJson)
                .forEach(([index, currentRepo]) => {

                    const li = document.createElement('li');
                    li.textContent = `${currentRepo.commit.author.name}: ${currentRepo.commit.message}`;
                    commitsUl.appendChild(li);
                });

            username.value = '';
            repo.value = '';

        } else if (!response.ok) {

            throw new Error(JSON.stringify({

                status: response.status,
                statusText: response.statusText
            }));
        }

    } catch (data) {

        const error = JSON.parse(data.message);
        const li = document.createElement('li');
        li.textContent = `Error: ${error.status} (${error.statusText})`;
        commitsUl.appendChild(li);

        username.value = '';
        repo.value = '';
    }
}