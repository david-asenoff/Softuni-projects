function create(words) {

   const contentDiv = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      let title = words[i];

      const div = document.createElement('div');
      const paragraph = document.createElement('p');
      paragraph.style.display = "none";
      paragraph.textContent = title;
      div.appendChild(paragraph);
      contentDiv.appendChild(div);
   }
   // querySelectorAll() Method - Get all elements in the document with class="example":
   [...document.querySelectorAll('div')].forEach(div => div.addEventListener('click', function (e) {
      e.preventDefault();
   // Get the HTML content of the first child element
      div.firstElementChild.style.display = "block";
   }))
}