// Get the state of grid layout.
export const getLayoutData = (state) => {
  return state.gridLayout
}

// Get the state of the grid layout list got the table.
export const getTableData = (state) => {
  console.log('TABLEDATA')
  console.log(state.tableData)
  return state.tableData
}

// Get the state of the fetched grid layout list.
export const getFetchedGridlayouts = (state) => {
  return state.fetchedGridlayouts
}
