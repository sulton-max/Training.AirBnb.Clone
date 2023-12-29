<template>

    <div class="h-[80px] min-w-[50px] flex flex-col justify-center items-center group select-common cursor-pointer select-none">

        <!-- Category icon -->
        <img class="h-[24px] w-[24px] mb-2 primary-transition whitespace-nowrap dark:invert" 
            :class="isSelected ? 'selected-opacity' : 'opacity-60 select-opacity'"
            :src ="listingCategory.imageUrl" 
            :alt="`${listingCategory.name} icon`">

        <!-- Category name -->
        <h5 class="text-xs font-medium text-black primary-transition whitespace-nowrap dark:text-white"
            :class="isSelected ? 'selected-opacity' : 'opacity-40 select-opacity'">
            {{ listingCategory.name }}
        </h5>

        <!-- Category underline -->
        <div class="mt-[10px] h-[2px] w-4/5 primary-transition theme-bg-accent whitespace-nowrap"
            :class="isSelected ? 'selected-opacity bg-black dark:bg-white' : 'opacity-0 select-opacity'"></div>
    </div>
    
</template>
    
<script setup lang="ts">
import type { ListingCategory } from "@/modules/locations/models/ListingCategory"; 
import { computed } from "vue";


const props = defineProps({
    listingCategory: {
        type: Object as () => ListingCategory,
        required: true
    },
    selectedCategoryId: {
        type: String,
        required: true
    }
});

const isSelected = computed(() => props.selectedCategoryId === props.listingCategory.id);
</script>