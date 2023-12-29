<template>

    <button class="flex items-center justify-center w-10 h-10 ml-3 rounded-full md:hidden theme-border theme-shadow hover-shadow-zero primary-transition"
            :class="{'hidden': !isMobile}">
        <svg class="h-4 w-4 theme-icon-primary stroke-[2px]"
             xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"
             aria-hidden="true"
             role="presentation"
             focusable="false">
            <path fill="none"
                  d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3">
            </path>
        </svg>
    </button>

    <button class="flex items-center justify-center w-auto h-12 gap-3 px-4 ml-3 rounded-lg group theme-border" :class="{'hidden': isMobile}">
        <svg class="w-4 h-4 stroke-current theme-icon-primary" 
            xmlns="http://www.w3.org/2000/svg" 
            viewBox="0 0 32 32" 
            aria-hidden="true" 
            role="presentation" 
            focusable="false" 
            style="display: block; 
            fill: none; 
            stroke-width: 3; 
            overflow: visible;">
            <path fill="none" d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
        </svg>
        <span class="theme-text-primary">Filters</span>
    </button>

</template>

<script setup lang="ts">

const props = defineProps({
    isMobile: {
        type: Boolean,
        required: true
    }
});

</script>