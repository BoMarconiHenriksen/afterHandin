<template>
  <!-- Checkbox -->
  <div class="q-gutter-sm" style="position: absolute; bottom: 0px; right: 55px;">
    <q-checkbox color="black"  dense left-label v-model="val" label="Lås" @input="updateLockOnComponent({ key: item.i, val: val })">
      <q-tooltip
          transition-show="scale"
          transition-hide="scale"
        >
            Lås placeringen af din widget.
        </q-tooltip>
      </q-checkbox>
  </div>

</template>

<script>
import { mapActions } from 'vuex'

export default {
  props: ['item'],
  data () {
    return {
      val: false
    }
  },
  methods: {
    ...mapActions([
      'updateLockOnComponent'
    ])
  }
}
</script>
