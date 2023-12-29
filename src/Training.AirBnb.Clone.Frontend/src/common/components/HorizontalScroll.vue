<template>

    <!-- Previous button -->
    <previous-button v-if="canScrollPrev" class="mb-3 theme-bg-primary hover-shadow-zero" @click="onScrollPrev"/>

    <div ref="scrollContainer" class="flex gap-10 overflow-x-scroll md:gap-12 no-scrollbar">
        
        <slot v-bind="$attrs"></slot>
    </div>

    <!-- Next button -->
    <next-button v-if="canScrollNext" class="mb-3 theme-bg-primary hover-shadow-zero" @click="onScrollNext"/>

</template>

<script setup lang="ts">

import NextButton from './NextButton.vue';
import PreviousButton from './PreviousButton.vue';
import { ref, type PropType, watch, onMounted, onUnmounted, nextTick } from 'vue';
import { DocumentService } from "@/infrastructure/services/DocumentService";

const scrollContainer = ref<HTMLDivElement>();
const documentService = new DocumentService();

const props = defineProps({
   scrollChangeSource: {
        type: Array as PropType<Array<any>>,
        required: true
   },
   scrollDistance: {
        type: Number as PropType<number>,
        required: false,
        default: 450
   }
});

const scrollPosition = ref<number>(0);
const canScrollPrev = ref<boolean>(true);
const canScrollNext = ref<boolean>(true);
const isMounted = ref<boolean>(false);
const firstComputed = ref<boolean>(false);

watch(() => [props.scrollChangeSource], () => {
    if (firstComputed.value) return;
    
    nextTick(() => {
        computeCanScroll();
        firstComputed.value = true; 
    });
});

const computeCanScroll = () => {
  canScrollPrev.value = documentService.canScrollLeft(scrollContainer.value!);
  canScrollNext.value = documentService.canScrollRight(scrollContainer.value!);  
};

onMounted(() => {
   if (!scrollContainer.value) return; 

   documentService.addEventListener(scrollContainer.value, "scroll", onScroll);

   isMounted.value = true;
});

onUnmounted(() => {
   if (!scrollContainer.value) return;
   
   documentService.removeEventListener(scrollContainer.value, "scroll", onScroll);
});

const onScrollPrev = () => {
  if (!scrollContainer.value) return;  

  documentService.scrollLeft(scrollContainer.value, props.scrollDistance);
};

const onScrollNext = () => {
    if (!scrollContainer.value) return;

    documentService.scrollRight(scrollContainer.value, props.scrollDistance);
}

const onScroll = (target: HTMLElement) => {
    scrollPosition.value = target.scrollLeft;
    computeCanScroll();
}

</script>