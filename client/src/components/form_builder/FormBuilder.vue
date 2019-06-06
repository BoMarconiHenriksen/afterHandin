<template>
   <q-page>
      <H2>Form Builder</H2>

      <div class="q-pa-md q-gutter-sm">

      <q-btn class="float-left" color="white" text-color="black" label="Input Felt" @click="addInputFieldToGrid" />

      <br>
      </div>
      <!-- Create the grid layout -->
      <grid-layout
        :key="rerenderKey"
        :layout="getLayoutData"
        :col-num="12"
        :row-height="40"
        :is-draggable=true
        :is-resizable=true
        :is-mirrored="false"
        :vertical-compact="false"
        :margin="[15, 15]"
        :use-css-transforms="true">

      <grid-item v-for="(item, index) in getLayoutData" :key="item.i"
         :autoSize="true"
         :x="item.x"
         :y="item.y"
         :w="item.w"
         :h="item.h"
         :i="item.i"
         :static="item.static">

         <template>
            <!-- Show component. item og itemIndex is passed as props.-->
            <component v-if="item.isComponent"
            :is="item.component"
            :item="item"
            :itemIndex="index">
            </component>

            <app-delete-alert :item="item"/>

         </template>

         </grid-item>
      </grid-layout>

      <br>
      <q-input outlined v-model="templateName" label="Skabelon Navn" style="width: 150px" />
      <br>
      <q-btn class="float-left" color="white" text-color="black" label="Gem Skabelonen" @click="addTemplate" />

      <appGetTemplateComponent />

   </q-page>
</template>

<script>
import { GridLayout, GridItem } from 'vue-grid-layout'
import { mapGetters, mapActions } from 'vuex'
import InputFieldComponent from './widgets/InputFieldComponent.vue'
import DeleteAlert from './helper_components/DeleteAlert.vue'
import GetTemplateComponent from './crud_components/GetTemplateComponent.vue'

export default {
  components: {
    appInputFieldComponent: InputFieldComponent,
    appDeleteAlert: DeleteAlert,
    appGetTemplateComponent: GetTemplateComponent,
    GridLayout,
    GridItem
  },
  data () {
    return {
      templateName: '',
      rerenderKey: 0
    }
  },
  methods: {
    ...mapActions([
      'addInputFieldToGrid',
      'editLabel',
      'fetchFormsFromDb',
      'postTemplate'
    ]),
    addTemplate () {
      let templateName = this.templateName
      let layoutFromFormBuilder = this.getLayoutData

      let templateToAdd = { name: '', completedForms: [{ completedDate: null, formFieldValues: [{ value: '' }] }], formFields: [{ id: 0, column: null, component: { id: 0, componentName: '', formFieldId: 0 }, headline: '', height: null, row: null, static: null, width: null, formFieldValues: [] }] }

      // TODO: See if Grid Layout has mapping between objects
      templateToAdd.name = templateName
      templateToAdd.formFields[0].column = layoutFromFormBuilder[0].x
      templateToAdd.formFields[0].headline = layoutFromFormBuilder[0].inputFieldHeader
      templateToAdd.formFields[0].height = layoutFromFormBuilder[0].h
      templateToAdd.formFields[0].row = layoutFromFormBuilder[0].y
      templateToAdd.formFields[0].static = layoutFromFormBuilder[0].static
      templateToAdd.formFields[0].width = layoutFromFormBuilder[0].w
      templateToAdd.formFields[0].component.componentName = layoutFromFormBuilder[0].component

      let today = new Date().toLocaleString()
      templateToAdd.completedForms[0].completedDate = today

      this.postTemplate(templateToAdd)
      // Clear fields after click
      this.templateName = ''
      // Reload the component
      this.rerenderKey += 1
    }
  },
  computed: {
    ...mapGetters([
      'getLayoutData',
      'getFetchedGridlayouts'
    ])
  }
}
</script>

<style>
.vue-grid-layout {
  background: #eee;
}

.vue-grid-item:not(.vue-grid-placeholder) {
  background: #ccc;
  border: 1px solid black;
}

.vue-grid-item.resizing {
  opacity: 0.9;
}

.vue-grid-item.static {
  background: #cce;
}

.vue-grid-item .text {
  font-size: 24px;
  text-align: center;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
  height: 24px;
}

.vue-grid-item .minMax {
  font-size: 12px;
}

.vue-grid-item .add {
  cursor: pointer;
}

.float-left {
   float:left;
   margin-right: 15px;
}
</style>
