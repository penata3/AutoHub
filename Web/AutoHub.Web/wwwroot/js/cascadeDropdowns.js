document.getElementById('RegionId').addEventListener('click', async (e) => {
    const townSelectElement = document.getElementById('TownId');
    townSelectElement.innerHTML = "<option disabled value=''>Select town</option>";

    const response = await fetch(`/regiontowns/getTowns?Id=${e.target.value}`);
    const data = await response.json();

    data.forEach(town => {
        townSelectElement.innerHTML += `<option value="${town.id}">${town.name}</option>`
    });
});


document.getElementById('MakeId').addEventListener('click', async (e) => {
    const modelSelectList = document.getElementById('ModelId');
    modelSelectList.innerHTML = "<option disabled value=''>Select model</option>";

    const response = await fetch(`/carmodels/getModels?Id=${e.target.value}`);
    const data = await response.json();

    data.forEach(model => {
        modelSelectList.innerHTML += `<option value="${model.id}">${model.name}</option>`;
    })
})