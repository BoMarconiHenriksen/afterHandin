import Vue from 'vue'
import Vuex from 'vuex'
import state from './layouts/state'
import * as getters from './layouts/getters'
import * as mutations from './layouts/mutations'
import * as actions from './layouts/actions'

Vue.use(Vuex)

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation
 */

export default function (/* { ssrContext } */) {
  const Store = new Vuex.Store({
    state,
    getters,
    mutations,
    actions
  })

  return Store
}
