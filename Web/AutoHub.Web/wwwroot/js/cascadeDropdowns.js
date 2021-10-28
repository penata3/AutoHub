document.getElementById('RegionId').addEventListener('change', async (e) => {
    const townSelectElement = document.getElementById('TownId');
    townSelectElement.innerHTML = "<option disabled value=''>Select town</option>";

    var regionId = e.target.value;

   

    const response = await fetch(`/regiontowns/getTowns?Id=${regionId}`);
        const data = await response.json();

        data.forEach(town => {
            townSelectElement.innerHTML += `<option value="${town.id}">${town.name}</option>`
        });

});


document.getElementById('MakeId').addEventListener('change', async (e) => {
    const modelSelectList = document.getElementById('ModelId');
    modelSelectList.innerHTML = "<option disabled value=''>Select model</option>";

    //parse the event target value to see if it is validnumber

    var parsedMakeId = parseInt(e.target.value);


    if (parsedMakeId) {

           const response = await fetch(`/carmodels/getModels?Id=${e.target.value}`);
         const data = await response.json();
        data.forEach(model => {
            modelSelectList.innerHTML += `<option value="${model.id}">${model.name}</option>`;
      })
    }

 

  

   
})