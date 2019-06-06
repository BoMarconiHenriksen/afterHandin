import axios from 'axios'
import state from '../layouts/state'

// Running the cluster with minikube or GKE
// const baseUrl = '/api'
// local development. Run npm install, quasar dev and run .Net Core
const baseUrl = 'https://localhost:5001/api'

import initialLayoutData from '../../assets/savedLayouts/demo.json'

// Array for generated ids.
var usedIds = []

// Sets the initial gridlayout with an input widget.
export const getInitialLayout = ({ commit }) => {
  console.log('I action.js ' + initialLayoutData)

  commit('saveLayout', initialLayoutData)
}

// Action to add an input field item to the state through a mutation.
export const addInputFieldToGrid = ({ commit, state }) => {
  let inputFieldLayout = {
    'x': 0, // Horizontal position of the item (in which column it should be placed).
    'y': 0, // Vertical position of the item (in which row it should be placed).
    'w': 2, // Width of the item.
    'h': 2, // Height of the item.
    'i': 'componentIndex', // Id of the item.
    'component': 'appInputFieldComponent',
    'isComponent': true,
    'content': '',
    'static': false
  }

  // TODO: Change this to a counter!
  var randomNumber = generateRandomNumber()
  let running = true
  var componentIndex = null

  while (running) {
    if (usedIds.includes(randomNumber) === true) {
      let newRandomNumber = generateRandomNumber()
      randomNumber = newRandomNumber
    } else {
      usedIds.push(randomNumber)
      componentIndex = randomNumber
      running = false
    }
  }

  inputFieldLayout.i = componentIndex

  commit('setNewGridItem', inputFieldLayout)
}

// Remove item from the state through mutation.
export const removeItem = ({ commit }, payload) => {
  commit('removeItem', payload)
}

// Save header and text from input Field.
export const saveInputField = ({ commit }, payload) => {
  console.log(payload)
  commit('saveNameOfInputField', payload)
}

// Update lock on component.
export const updateLockOnComponent = ({ commit }, payload) => {
  commit('saveLockOnComponent', payload)
}

// Clear layout in store af save.
export const clearLayout = ({ commit }, payload) => {
  commit('clarLayoutInStore', payload)
}

// Fetch the forms from the database
export async function fetchFormsFromDb ({ commit }) {
  // commit('setLoading', true)
  try {
    const response = await axios.get(`${baseUrl}/Forms/`)
    commit('getListOfGridItems', response.data)
  } catch (err) {
    console.log(err)
  }
  //  commit('setLoading', false)
}

// Update table row in database
export async function updateRow ({ commit }, row) {
  // We have to map the data from the table to match the data in the database

  var lastFetch = getStateOfTableData()
  console.log('POST1')
  console.log(row)
  console.log(row.id)
  console.log(lastFetch)
  // Find the row from state to update
  const rowToUpdate = lastFetch.filter((tableRow) => tableRow.id === row.id)
  console.log(rowToUpdate)
  rowToUpdate[0].name = row.name
  rowToUpdate[0].id = row.id
  rowToUpdate[0].formFields[0].headline = row.headline

  try {
    await axios.put(`${baseUrl}/Forms/${row.id}`, rowToUpdate[0])
    commit('storeUpdateRow', row)
  } catch (err) {
    console.log(err)
  }
}

// Post new item
export async function postTemplate ({ commit }, template) {
  try {
    // console.log('POST ' + template)
    const response = await axios.post(`${baseUrl}/Forms/`, { id: template.id, name: template.name, formFields: template.formFields, completedForms: template.completedForms })
    // console.log(response)
    const idFromDb = response.data.id
    template.id = idFromDb
    // console.log('up ' + idFromDb)
    commit('updateTableAfterPost', response.data)
  } catch (err) {
    console.log(err)
  }
}

// Delete table row in database
export async function deleteRow ({ commit }, id) {
  try {
    axios.delete(`${baseUrl}/Forms/${id}`)
    commit('storeDeleteRow', id)
  } catch (err) {
    console.log(err)
  }
}

// Helper methods for generating and checking random numbers for the id.
function generateRandomNumber () {
  let generatedNumber = Math.floor(Math.random() * Math.floor(10000000))
  return generatedNumber
}

// Helper method that get the state of the initial fetch
function getStateOfTableData () {
  let fetchedGridlayouts = state.fetchedGridlayouts
  return fetchedGridlayouts
}
