// Mutation set layoutData in state for initial run.
export const saveLayout = (state, initialLayoutData) => {
  state.gridLayout = initialLayoutData
}

// Mutation new basic grid item in gridLayout.
export const setNewGridItem = (state, inputFieldLayout) => {
  state.gridLayout.push(inputFieldLayout)
}

// Clear the gridlayout after save.
export const clarLayoutInStore = (state, payload) => {
  state.gridLayout.length = 0
}

// List of templates from backend.
export const getListOfGridItems = (state, payload) => {
  let tableData = [ ]
  // We have to map the fetched data so the table can show the data
  for (let key in payload) {
    const template = { }

    template.id = payload[key].id
    template.name = payload[key].name
    template.completedDate = payload[key].completedForms[0].completedDate
    template.headline = payload[key].formFields[0].headline

    tableData.push(template)
  }
  state.tableData = tableData
  state.fetchedGridlayouts = payload
}

// Update table after a post
export const updateTableAfterPost = (state, template) => {
  let newEntity = [ ]

  newEntity.id = template.id
  newEntity.name = template.name
  newEntity.completedDate = template.completedForms[0].completedDate
  newEntity.headline = template.formFields[0].headline

  state.tableData.push(newEntity)
}

// Update row in state after put in action
export const storeUpdateRow = (state, payload) => {
  // We have to map the response so it match the structure of the table
  const tableData = state.tableData.filter((row) => row.id === payload.id)

  // We don't map this because we have to use it to show in the table.
  if (tableData.length === 1) {
    tableData[0].name = payload.name
    tableData[0].headline = payload.headline
    state.tableData[tableData[0].id] = tableData[0]
  }
}

// Delete row in state after delete action
export const storeDeleteRow = (state, id) => {
  let tableData = state.tableData.filter((row) => row.id === id)
  if (tableData.length === 1) {
    state.tableData.splice(state.tableData.indexOf(tableData[0]), 1)
  }
}

// Mutation to remove item from gridLayout.
export const removeItem = (state, payload) => {
  // Be sure static is false when deleting.
  for (let x in state.gridLayout) {
    console.log(state.gridLayout[x])
    if (state.gridLayout[x].i === payload.key) {
      state.gridLayout.splice(state.gridLayout.indexOf(state.gridLayout[x]), 1)
    }
  }
}

// Save name of input field
export const saveNameOfInputField = (state, payload) => {
  state.gridLayout[payload.itemIndex] = payload.item
}

// Save lock on component in state
export const saveLockOnComponent = (state, payload) => {
  for (let x in state.gridLayout) {
    if (state.gridLayout[x].i === payload.key) {
      state.gridLayout[x].static = payload.val
    }
  }
}
